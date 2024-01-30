---
title: Unity Scroll View (uGUI) で、動的に有効にしたスクロールバーが操作できない
tags: Unity C# uGUI
---
# 課題
- `Unity 2022`だと、`ScrollRect`で、インスペクタでチェックされていない方向(縦横)をスクリプトから`true`にすると、スクロールバーを操作してもコンテンツがスクロールしません。
  - `ScrollBar`の`Visibility`は`Auto Hide And Expand Viewport`です。
- スクロールホイールやコンテンツのドラッグによる操作は可能で、操作の結果はスクロールバーにも反映されます。
- `Unity 2021.3`では、同じ方法で動的にスクロール方向の可否を切り替えても、スクロールバーによる操作が可能でした。

## 確認した環境
- Unity 2022.1.0 ~ 2022.3.18f1

# 原因
- インスペクタでスクロールバーの割り当てが行われていても、インスペクターで無効な向きのスクロールバーにはリスナーが設定されず、動的に向きを有効にしても再設定されません。

# 対処
- スクロールバー・オブジェクトを変更するとリスナーが設定されることを利用して、スクロール方向の切り替え時にリスナーを有効化します。

```csharp
    scroll.vertical = true;
    scroll.verticalScrollbar = scroll.verticalScrollbar;
    scroll.horizontal = true;
    scroll.horizontalScrollbar = scroll.horizontalScrollbar;
```

- なお、スクロールバーのリスナーは、`MonoBehaviour`の`OnEnable`時にも再設定されるようです。

# 実証プロジェクト
## 使い方
- エディタ上で実行した時点では、スクロールは無効です。
- ボタンを押すと、縦横にスクロール可能になります。
  - しかし、この時点では、スクロールバーを操作してもコンテンツ位置に反映されません。
- 再度ボタンを押すと、スクロールバーで操作可能になります。
