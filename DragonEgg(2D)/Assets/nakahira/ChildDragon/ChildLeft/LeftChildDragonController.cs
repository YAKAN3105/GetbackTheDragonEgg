using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DragonRace;

public class LeftChildDragonController : MonoBehaviour
{
    // �A�j���[�V������؂�ւ���

    private TestDragonStatus myStatus;
    private Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        // �Ґ���������󂯎��
        myStatus = BattleTeam.sChildDragonDataLeft;
        Debug.Log(myStatus);
        switch (myStatus.raceNum)
        {
            case races.player:
                myAnimator.SetTrigger("Player");
                break;
            case races.fire:
                myAnimator.SetTrigger("Fire");
                break;
            case races.ice:
                myAnimator.SetTrigger("Ice");
                break;
            case races.wind:
                myAnimator.SetTrigger("Wind");
                break;
            case races.thunder:
                myAnimator.SetTrigger("Thunder");
                break;
            case races.none:
                myAnimator.SetTrigger("Empty");
                break;
            default:
                myAnimator.SetTrigger("Error");
                Debug.Log("Error!!");
                break;
        }
    }


}
