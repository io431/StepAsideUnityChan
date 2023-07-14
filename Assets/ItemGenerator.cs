using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //cornPrefab������
    public GameObject conePrefab;
    public GameObject unitychan;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    private float lastGeneratedPos;

    void Start()
    {

        this.unitychan = GameObject.Find("unitychan");
        lastGeneratedPos = 15;

    }
    // Update is called once per frame
    void Update()
    {
        // ���j�e�B�����̌��݂̈ʒu���擾
        float unityChanPos = unitychan.transform.position.z;

        // ���j�e�B�����̐i�s�ɉ����ăA�C�e���𐶐�
        if (unityChanPos + 50> lastGeneratedPos && unityChanPos + 50 < goalPos )
        {
            // �A�C�e�������ʒu���X�V
            lastGeneratedPos += 10;

            // �ǂ̃A�C�e�����o���̂��������_���ɐݒ�
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                // �R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, lastGeneratedPos);
                }
            }
            else
            {
                // ���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    // �A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);
                    // �A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);
                    // 60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        // �R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, lastGeneratedPos + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        // �Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, lastGeneratedPos + offsetZ);
                    }
                }
            }
        }
    }
}