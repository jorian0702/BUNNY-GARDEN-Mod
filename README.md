# BUNNY GARDEN - Unlimited Money Mod

BUNNY GARDEN 用の非公式 BepInEx プラグインです。

## 機能

- **無限マネー** -- お金を使っても減らず、逆に増える
- **所持金自動MAX** -- ゲーム開始時に所持金が 9,999,999 に設定される
- **GetMoney パッチ** -- 所持金が減っていた場合、自動的に MAX に補正

## 技術スタック

- C# / .NET Standard 2.1
- [BepInEx 5](https://github.com/BepInEx/BepInEx) (Unity Mono)
- [HarmonyX](https://github.com/BepInEx/HarmonyX) によるランタイムパッチ

## ビルド

```bash
dotnet build ModTools/UnlimitedMoneyMod/UnlimitedMoneyMod.csproj -c Release
```

出力先: `ModTools/UnlimitedMoneyMod/bin/Release/netstandard2.1/UnlimitedMoneyMod.dll`

## インストール

1. [BepInEx 5](https://github.com/BepInEx/BepInEx/releases) をゲームディレクトリに導入
2. ビルドした `UnlimitedMoneyMod.dll` を `BepInEx/plugins/` に配置
3. ゲームを起動

## ダウンロード

[Releases](../../releases) からビルド済み DLL をダウンロードできます。

## 免責事項

本プロジェクトは非公式のファンメイドMODであり、ゲーム開発元とは一切関係ありません。自己責任でご利用ください。
