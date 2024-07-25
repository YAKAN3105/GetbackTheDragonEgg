using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // scene�؂�ւ����s������
using UnityEngine.EventSystems;

// �t�F�[�h�C���A�t�F�[�h�A�E�g�Ǘ��X�N���v�g

public class FadeManager : MonoBehaviour
{
    float time = 0.0f;
    float fadeSpeed = 1.0f;        //�t�F�[�h���鑬�x �b
    float red, green, blue, alpha;  //alfa���炢�����g��Ȃ�
    string loadScene = "TestErrorScene";  // ���[�h����V�[���̖��O

    // �t�F�[�h�C���A�t�F�[�h�A�E�g���Ǘ�����X�C�b�`
    public bool Out = false;
    public bool In = false;

    Image fadeImage;    //�p�l��

    // ���̃X�N���v�g���g���ۂ�
    // �E�p�l����Image�̃`�F�b�N�{�b�N�X��؂�
    // �E�p�l����alfa��255�ɐݒ�
    // �E�V�[���ڍs����{�^������ FadeOutSwitch(int number) �𑗂�悤�ɐݒ肷��

    void Start()
    {
        // �p�l���̐F�A�s�����x���
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;

        // �V�[�����ǂݍ��܂ꂽ�Ƃ��Ƀt�F�[�h�C������
        FadeInSwitch();
    }

    void Update()
    {

        // �X�C�b�`���I���ɂȂ��Ă���Ȃ炻�ꂼ��̏���
        if (In)
        {
            FadeIn();
        }

        if (Out)
        {
            FadeOut();
        }

    }

    public void FadeInSwitch()
    {
        fadeImage.enabled = true;
        In = true;
    }

    public void FadeOutSwitch(int number)  // �{�^������󂯎�����������Ƃ炵���킹��
    {
        // �R���g���[���[�Ή�
        if (0 < Input.GetAxisRaw("Vertical"))
        {
            // �I�𒆂̃I�u�W�F�N�g�擾
            GameObject nowObj = EventSystem.current.currentSelectedGameObject;
        }

        if (number != 0)
        {
            LoadingScene.stageNum = number;
        }

        switch (LoadingScene.stageNum)  // �V�[���؂�ւ�
        {
            //case 100:
            //    loadScene = "TestStageSelectScene";
            //    break;
            case 100:
                loadScene = "StageSelectScene";
                break;
            case 101:
                loadScene = "HomeScene";
                break;

            case 102:
                loadScene = "ReinforcementScene";  // "ren"
                break;
            case 103:
                loadScene = "OptionScene";
                break;


            //case 1:
            //    loadScene = "TestStage1";
            case 1:
                loadScene = "Battle";
                break;
            case 2:
                loadScene = "TestStage2";
                break;
            case 3:
                loadScene = "TestStage3";
                break;
            case 4:
                loadScene = "TestStage4";
                break;

            case 11:
                loadScene = "TestFade1";
                break;
            case 12:
                loadScene = "TestFade2";
                break;

            default:
                loadScene = "TestErrorScene";
                break;


        }

        // �s�����x��0(����)�ɂ��A�t�F�[�h�A�E�g�����J�n
        alpha = 0;
        Out = true;
    }

    private void FadeIn()    // �t�F�[�h�C������
    {
        // �s�����x��fadeSpeed�����炷
        //alpha -= fadeSpeed;
        time += Time.deltaTime;
        alpha = 1.0f - time / fadeSpeed;
        //alpha -= fadeSpeed * Time.deltaTime;
        ChangeColor();
        if (alpha <= 0)
        {
            In = false;
            fadeImage.enabled = false;
        }
    }

    private void FadeOut()    // �t�F�[�h�A�E�g����
    {
        fadeImage.enabled = true;
        // �s�����x��fadeSpeed�����₷
        //alpha += fadeSpeed;
        time += Time.deltaTime;
        alpha = 1.0f - time / fadeSpeed;
        //alpha += fadeSpeed * Time.deltaTime;
        ChangeColor();

        // ���S�ɕs�����ɂȂ�����V�[���ڍs
        if (alpha >= 1)
        {
            Out = false;
            SceneManager.LoadSceneAsync(loadScene);
        }
    }

    // ���������𔽉f
    private void ChangeColor()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }
}
