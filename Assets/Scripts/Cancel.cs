using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Cancel : MonoBehaviour
{
    private async UniTaskVoid Start()
    {
        var cancellationTokenSource = new CancellationTokenSource();

        // 5秒後にタスクをキャンセル
        cancellationTokenSource.CancelAfter( 5000 );

        try
        {
            await LongRunningTask( cancellationTokenSource.Token );
            Debug.Log( "Task completed successfully." );
        }
        catch( OperationCanceledException )
        {
            Debug.Log( "Task was canceled." );
        }
    }

    private async UniTask LongRunningTask( CancellationToken token )
    {
        Debug.Log( "Task started." );

        for( int i = 0; i < 10; i++ )
        {
            // タスクがキャンセルされているかどうかを頻繁にチェック
            token.ThrowIfCancellationRequested();

            // ここでの処理はシミュレーションのため、実際の長い処理を模倣する
            await UniTask.Delay( 1000, cancellationToken: token ); // 1秒待つ
            Debug.Log( $"Task running... {i + 1}/10" );
        }

        Debug.Log( "Task finished." );
    }
}