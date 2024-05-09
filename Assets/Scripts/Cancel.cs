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

        // 5�b��Ƀ^�X�N���L�����Z��
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
            // �^�X�N���L�����Z������Ă��邩�ǂ�����p�ɂɃ`�F�b�N
            token.ThrowIfCancellationRequested();

            // �����ł̏����̓V�~�����[�V�����̂��߁A���ۂ̒���������͕킷��
            await UniTask.Delay( 1000, cancellationToken: token ); // 1�b�҂�
            Debug.Log( $"Task running... {i + 1}/10" );
        }

        Debug.Log( "Task finished." );
    }
}