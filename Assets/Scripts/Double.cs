using Cysharp.Threading.Tasks;
using UnityEngine;

public class Double : MonoBehaviour
{
    private const int DoubleClickThresholdMilliseconds = 300; // ダブルクリックとして認識する時間の閾値（ミリ秒）

    private async UniTaskVoid Start()
    {
        while( true )
        {
            if( await IsDoubleClickAsync() )
            {
                Debug.Log( "Double clicked!" );
            }

            await UniTask.Yield(); // 1フレーム待機
        }
    }

    private async UniTask<bool> IsDoubleClickAsync()
    {
        await UniTask.WaitUntil( () => Input.GetMouseButtonDown( 0 ) );
        var timeOut = UniTask.Delay( DoubleClickThresholdMilliseconds ); // 閾値の時間だけ待機
        var mouseDown = UniTask.WaitUntil( () => Input.GetMouseButtonDown( 0 ) );
        var completedTaskIndex = await UniTask.WhenAny( mouseDown, timeOut );

        return completedTaskIndex == 0;
    }
}