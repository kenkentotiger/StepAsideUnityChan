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
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;

    // Update is called once per frame
    void Update()
    {
        this.unitychan = GameObject.Find("unitychan");
        //Unity�����Ƃ̈ʒu�̍���2�ȏ�̏ꍇ�A�A�C�e�����폜
        if (this.unitychan.transform.position.z - this.transform.position.z > 3)
        {
            Destroy(this.gameObject);
        }
    }
}
