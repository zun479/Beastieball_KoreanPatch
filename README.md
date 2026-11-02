# Beastieball 비공식 한국어 패치

[Beastieball](https://store.steampowered.com/app/1864950/Beastieball/)을 한국어로 플레이할 수 있게 해 주는 **비공식 팬 패치**입니다.

> ⚠️ 이 프로젝트는 개발사 Wishes Unlimited와 관련이 없습니다.

## 번역 범위 (v0.1)

| 분류 | 진행 |
|---|---|
| 메인 화면·메뉴 | ✅ 거의 완료 |
| 설정 | ✅ 거의 완료 |
| 튜토리얼 설명·도감 | ✅ 완료 |
| 스토리 대사 | 🟡 초반 일부 |
| 인게임 UI·비스티/기술 데이터 | ⬜ 영어로 표시 |

번역되지 않은 문장은 영어 원문으로 표시됩니다.

## 구성

```
loc/한국어.csv                      번역 파일 (게임의 loc 폴더에 넣음)
korean_font_patch/
  ApplyKoreanFont.csx               한글 폰트 패치 스크립트 (UndertaleModTool용)
  ftTextCN_ko.png                   한글이 추가된 SDF 글자 이미지
  ko_glyphs.csv                     추가 글자 위치 정보
설치방법.txt                         설치·업데이트·되돌리기 방법
```

## 왜 폰트 패치가 필요한가요?

Beastieball은 게임을 빌드할 때 쓰이는 글자만 텍스처로 구워 넣습니다. 기본 폰트에는 한글이 없어서, 번역 파일만 넣으면 한글이 빈칸으로 보입니다.
이 패치는 사용자의 `data.win`에 있는 CJK 폰트(`ftTextCN`)에 한글 2,350자와 자모 51자를 추가합니다.
**게임 원본 파일은 배포하지 않으며**, 사용자가 자신의 게임 파일에 직접 패치를 적용하는 방식입니다.

## 설치

`설치방법.txt`를 참고하세요. 요약하면:

1. `data.win` 백업
2. `loc/한국어.csv`를 게임의 `loc` 폴더에 복사
3. [UndertaleModTool](https://github.com/UnderminersTeam/UndertaleModTool/releases) 0.9.2.0 이상으로 `data.win`을 열고 `ApplyKoreanFont.csx` 실행 후 저장
4. 게임 설정 → 언어 → 한국어

게임 업데이트 후 한글이 다시 빈칸으로 보이면 3번만 다시 하면 됩니다.

## 라이선스 및 권리 고지

- 이 저장소의 **패치 스크립트와 한국어 번역문**은 [MIT License](LICENSE)를 따릅니다.
- 게임의 영어 원문, 캐릭터, 이름, 기타 에셋의 저작권은 **Wishes Unlimited**에 있습니다. MIT 라이선스는 이 부분에 적용되지 않습니다.
- `ftTextCN_ko.png`의 글자 이미지는 모두 [Noto Sans CJK](https://github.com/notofonts/noto-cjk)로 새로 생성했으며, 게임에서 추출한 이미지를 포함하지 않습니다. Noto Sans CJK는 [SIL Open Font License 1.1](https://openfontlicense.org)을 따릅니다.
- 개발사의 요청이 있으면 이 저장소는 즉시 내려갑니다.

## 크레딧

- 게임: Wishes Unlimited
- 폰트 패치 도구: [UndertaleModTool](https://github.com/UnderminersTeam/UndertaleModTool) (Underminers Team)
- 폰트: Noto Sans CJK (Google / Adobe)
