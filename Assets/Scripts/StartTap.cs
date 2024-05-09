
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTap : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        Debug.Log( "スタートキーを待ちます" );
        await UniTask.WaitUntil(()=> Input.GetKeyDown( KeyCode.Space ) );
        Debug.Log("スタートキーが押されました");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
