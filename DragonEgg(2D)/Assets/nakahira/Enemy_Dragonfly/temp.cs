//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// �h���S��Box�̏����̒��ŌĂяo���Ă�
//public class DragonData
//{
//    // �L�^�ł���f�[�^�̐�
//    private const int DATANUMBER = 10;
//    // �L�[�̌Œ�̕���
//    private const string KEYBASE = "Dragon_";

//    // �h���S���̃f�[�^���������^�̔z������
//    // �f�[�^��0�Ԗڂ͐e�h���S���ɂ��悤
//    // �ł�����Q�[���������Ƒ��݂���͖̂��ʂ�����Ȃ��B�ׂɂ��������B
//    // 6/18�@Static�N���X�łȂ�������j�ɂ��܂���
//    public TestDragonStatus[] dragonData = new TestDragonStatus[DATANUMBER];

//    // �����o�֐�
//    public void LoadAllDragonData() // PlayerPlefs����S�f�[�^���擾
//    {
//        for (int i = 0; i < DATANUMBER; i++)
//        {
//            // KEYBASE�Z�Z�̌`�ŃL�[�����
//            string key = KEYBASE + i.ToString();

//            // TestDragonStatus�^�Ɋi�[
//            TestDragonStatus data = new TestDragonStatus(PlayerPrefs.GetString(key));
//            // �z��ɕۑ�
//            dragonData[i] = data;
//        }
//    }

//    public TestDragonStatus GetDragonData(int index)
//    {
//        return dragonData[index];
//    }

//    // �z��̃f�[�^��S��PlayerPrefs�ɕۑ�
//    public void SaveAllData()
//    {
//        // for �Ԃ�Ԃ�܂킷
//        for (int i = 0; i < DATANUMBER; i++)
//        {
//            SaveData(i);
//        }
//    }
//    // ��̃f�[�^�����Z�[�u
//    // �����̔Ԓn�̃f�[�^��ۑ�
//    public void SaveData(int index)
//    {
//        // playerprefs�ɕ�����string
//        string keyString = KEYBASE + index.ToString();
//        // ���o��
//        TestDragonStatus temp = dragonData[index];
//        // �Z�[�u
//        PlayerPrefs.SetString(keyString, temp.dataString);
//    }

//    //���܂����琶�܂ꂽ�Ƃ��ɃX�e�[�^�X�����߂�
//    public void EggCreate()
//    {
//        for (int i = 0; i < DATANUMBER; i++)
//        {
//            //�f�[�^���ׂ�
//            if (tempData.raceNum != 6)
//            {
//                continue;
//            }

//            TestDragonStatus temp = new TestDragonStatus();
//            // �������ǂ̎�ނ̃h���S���Ȃ̂�
//            temp.raceNum = 2;       //�Ƃ肠������������

//            // �̗́B�v���C���[�ɉ��Z����\��
//            temp.hp = 18;

//            // �U���́B�����e�̊�b�l�Ɋ|���Z�������
//            temp.attack = 10;

//            // �ړ��X�s�[�h
//            temp.fadeSpeed = 1.0f;

//            // ���O�B�ł�����
//            temp.name = "aaa";

//            // ���݃��x��
//            temp.level = 1;

//            // ���݂̌o���l
//            temp.nowExp = 100;

//            dragonData[i] = temp;

//            //�Z�[�u���邨
//            SaveData(i);

//            break;
//        }

//    }
//}
////����Z�[�u��ǉ�
//�R���e�L�X�g ���j���[����
