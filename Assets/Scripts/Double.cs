using Cysharp.Threading.Tasks;
using UnityEngine;

public class Double : MonoBehaviour
{
    private const int DoubleClickThresholdMilliseconds = 300; // �_�u���N���b�N�Ƃ��ĔF�����鎞�Ԃ�臒l�i�~���b�j

    private async UniTaskVoid Start()
    {
        while( true )
        {
            if( await IsDoubleClickAsync() )
            {
                Debug.Log( "Double clicked!" );
            }

            await UniTask.Yield(); // 1�t���[���ҋ@
        }
    }

    private async UniTask<bool> IsDoubleClickAsync()
    {
        await UniTask.WaitUntil( () => Input.GetMouseButtonDown( 0 ) );
        var timeOut = UniTask.Delay( DoubleClickThresholdMilliseconds ); // 臒l�̎��Ԃ����ҋ@
        var mouseDown = UniTask.WaitUntil( () => Input.GetMouseButtonDown( 0 ) );
        var completedTaskIndex = await UniTask.WhenAny( mouseDown, timeOut );

        return completedTaskIndex == 0;
    }
}