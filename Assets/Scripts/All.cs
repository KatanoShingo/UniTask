using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class All : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        var keyA = UniTask.WaitUntil( () => Input.GetKeyDown( KeyCode.A ) );
        var keyS = UniTask.WaitUntil( () => Input.GetKeyDown( KeyCode.S ) );
        var keyD = UniTask.WaitUntil( () => Input.GetKeyDown( KeyCode.D ) );
        var keyW = UniTask.WaitUntil( () => Input.GetKeyDown( KeyCode.W ) );

        await UniTask.WhenAll( keyA , keyS , keyD , keyW );

        Debug.Log("‘S•”‚ÌƒL[‚ª‰Ÿ‚³‚ê‚½");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
