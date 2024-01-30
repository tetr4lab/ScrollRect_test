using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// インスペクタで許可されていない方向のスクロールバーにリスナーが設定されなくなったため、動的な切り替え時に再設定する
public class ScrollRectTest : MonoBehaviour {

    private ScrollRect scroll;
    private Button button;
    private Text label;

    private void Start () {
        scroll = GetComponentInChildren<ScrollRect> ();
        button = GetComponentInChildren<Button> ();
        label = button.GetComponentInChildren<Text> ();
        label.text = "Scrollable";
        button.onClick.AddListener (() => {
            if (!scroll.vertical) {
                // スクロール可能に
                scroll.vertical = true;
                scroll.horizontal = true;
#if UNITY_2022_1_OR_NEWER
                label.text = "Handleable";
            } else if (button.interactable) {
                // ハンドル操作が反映されるように
                scroll.verticalScrollbar = scroll.verticalScrollbar;
                scroll.horizontalScrollbar = scroll.horizontalScrollbar;
#endif
                button.interactable = false;
                label.text = "Done";
            }
        });
    }

}
