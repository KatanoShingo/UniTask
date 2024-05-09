using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimeOut : MonoBehaviour
{
    async UniTaskVoid Start()
    {
        Debug.Log( "スタート" );
        var timeout = UniTask.Delay( 5000 ); // 5秒のディレイを設定
        var spaceKey = UniTask.WaitUntil( () => Input.GetKeyDown( KeyCode.Space ) ); // スペースキーが押されるのを待つ

        // 2つのタスク（timeoutとspaceKey）のうち、最初に完了したもののインデックスを取得
        var completedTaskIndex = await UniTask.WhenAny( spaceKey, timeout );

        if( completedTaskIndex == 0 ) // スペースキーが最初に押された場合
        {
            Debug.Log( "5秒以内にスペースキーが押されました" );
        }
        else // 5秒のディレイが先に完了した場合
        {
            Debug.Log( "何も押されませんでした" );
        }
    }
}
