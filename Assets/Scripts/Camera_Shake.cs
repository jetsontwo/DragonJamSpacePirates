using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Shake : MonoBehaviour {


    public IEnumerator Shake()
    {
        for(int i = 0; i < 7; ++i)
        {
            transform.Translate(new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f)));
            yield return new WaitForSeconds(0.03f);
        }
    }

    public IEnumerator little_shake()
    {
        for (int i = 0; i < 3; ++i)
        {
            transform.Translate(new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f)));
            yield return new WaitForSeconds(0.03f);
        }
    }
}
