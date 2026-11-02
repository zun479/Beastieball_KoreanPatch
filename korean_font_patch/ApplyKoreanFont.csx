// Beastieball Korean font patch: adds Hangul glyphs to ftTextCN
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UndertaleModLib.Util;

EnsureDataLoaded();
string dir = Path.GetDirectoryName(ScriptPath);
string pngPath = Path.Combine(dir, "ftTextCN_ko.png");
string csvPath = Path.Combine(dir, "ko_glyphs.csv");
if (!File.Exists(pngPath) || !File.Exists(csvPath)) { ScriptError("ftTextCN_ko.png / ko_glyphs.csv not found next to this script."); return; }

UndertaleFont font = Data.Fonts.ByName("ftTextCN");
if (font == null) { ScriptError("ftTextCN not found."); return; }
if (font.Glyphs.Any(g => g.Character == 0xAC00)) { ScriptError("Already patched (가 exists). Restore data.win.bak first."); return; }

UndertaleTexturePageItem tpi = font.Texture;
UndertaleEmbeddedTexture tex = tpi.TexturePage;
int users = Data.TexturePageItems.Count(t => t.TexturePage == tex);
if (users != 1) { ScriptError($"Texture page shared by {users} items; aborting."); return; }
if (tpi.SourceWidth != 2048 || tpi.SourceHeight != 2048) { ScriptError($"Unexpected font texture size {tpi.SourceWidth}x{tpi.SourceHeight}. Game was probably updated."); return; }

// 1) replace texture (2048x2048 -> 2048x4096, original CN glyphs kept in the top half)
tex.TextureData.Image = GMImage.FromPng(File.ReadAllBytes(pngPath));
tex.TextureWidth = 2048;
tex.TextureHeight = 4096;

// 2) texture page item: keep the same 2x scaling ratio as the original
tpi.SourceHeight = 4096;
tpi.TargetHeight = (ushort)(tpi.TargetHeight * 2);
tpi.BoundingHeight = (ushort)(tpi.BoundingHeight * 2);

// 3) add Hangul glyphs, keep list sorted by character
var all = font.Glyphs.ToList();
foreach (string line in File.ReadAllLines(csvPath))
{
    if (string.IsNullOrWhiteSpace(line)) continue;
    var p = line.Split(';');
    all.Add(new UndertaleFont.Glyph()
    {
        Character = ushort.Parse(p[0]),
        SourceX = ushort.Parse(p[1]),
        SourceY = ushort.Parse(p[2]),
        SourceWidth = ushort.Parse(p[3]),
        SourceHeight = ushort.Parse(p[4]),
        Shift = short.Parse(p[5]),
        Offset = short.Parse(p[6])
    });
}
font.Glyphs.Clear();
foreach (var g in all.OrderBy(g => g.Character)) font.Glyphs.Add(g);

ScriptMessage($"Done! ftTextCN now has {font.Glyphs.Count} glyphs.\nNow use File > Save to write data.win.");
