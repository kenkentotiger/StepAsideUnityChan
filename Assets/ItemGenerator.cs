using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;
    //���j�e�B�����̐i�񂾋���
    private float distance;
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //cornPrefab������
    public GameObject conePrefab;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    //�A�C�e���𐶐������|�W�V����
    private float insatantiatePosition;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        this.transform.position = new Vector3(0, this.transform.transform.position.y, this.unitychan.transform.position.z);

        //1.���j�e�B�����̐i�񂾋������v������v���O����������
        this.distance = this.unitychan.transform.position.z - insatantiatePosition;

        //�����ʒu���X�V����
        //���j�e�B�����̐i�񂾋���15m���ƂɃA�C�e���𐶐�����
        if (this.distance > 15)
        {
            this.insatantiatePosition = this.unitychan.transform.position.z;
            //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
            int num = Random.Range(1, 10);
            if (num <= 2)
            {
                //�R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    //2.�A�C�e���𐶐�������ʒu�����j�e�B������50m��ɂ���
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.unitychan.transform.position.z + 50);
                }
            }
            else
            {
                //���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 10);
                    //�A�C�e����u��z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);
                    //60%�R�C���z�u�F30%�Ԕz�u�F10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        //2.�A�C�e���𐶐�������ʒu�����j�e�B������50m��ɂ���
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.unitychan.transform.position.z + 50 + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        //2.�A�C�e���𐶐�������ʒu�����j�e�B������50m��ɂ���
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.unitychan.transform.position.z + 50 + offsetZ);
                    }
                }
            }
        }
    }
}



//1.���j�e�B�����̐i�񂾋������v������v���O����������
//1-1.�ȑO�A�C�e���𐶐������ʒu��ۑ����Ă���(50m�����ɃA�C�e���������j
//�ʒu��ۑ�����^�C�~���O���d�v�ɂȂ��Ă���B
//�i�񂾋��� = ���j�e�B�����̈ʒu - �ȑO�A�C�e���𐶐������ʒu 

//2.if���̃��j�e�B�����̐i�񂾋����ɉ����āA�A�C�e���𐶐�����
//1.�A�C�e���𐶐�����^�C�~���O�i���j�e�B�����̐i�s�ɍ��킹�āj
//2.�A�C�e���𐶐�������ʒu�����j�e�B������50m��ɂ���

