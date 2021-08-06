using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    // Update is called once per frame
    void Update()
    {
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとの位置の差が2以上の場合、アイテムを削除
        if (this.unitychan.transform.position.z - this.transform.position.z > 3)
        {
            Destroy(this.gameObject);
        }
    }
}
