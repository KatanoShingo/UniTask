using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class LongPressDetector : MonoBehaviour
{
    public float longPressThreshold = 1.0f; // ’·‰Ÿ‚µ‚Æ‚Ý‚È‚·•b”

    private async void Start()
    {
        await CheckForLongPress();
    }

    async UniTask CheckForLongPress()
    {
        while( true )
        {
            if( Input.GetMouseButtonDown( 0 ) )
            {
                var pressedTime = Time.time;
                bool isLongPressDetected = false;

                while( Input.GetMouseButton( 0 ) )
                {
                    if( Time.time - pressedTime >= longPressThreshold )
                    {
                        isLongPressDetected = true;
                        break;
                    }

                    await UniTask.Yield();
                }

                if( isLongPressDetected )
                {
                    Debug.Log( "Long Press Detected!" );
                }
            }

            await UniTask.Yield();
        }
    }
}
