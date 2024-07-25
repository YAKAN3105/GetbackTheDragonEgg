using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;

    private TestDragonStatus playerStatus;

    private float speed = 1f;
    //private Vector2 speedVec = Vector2.zero;
    private float hitPoint = 10;
    private int attack = 1;

    // �G�f�B�^�ŃA�^�b�`
    [SerializeField] private GameObject playerRapidBullet;
    [SerializeField] private GameObject playerFireBullet;

    private Camera cameraComponent;

    // �r���[�|�[�g�̕␳���`
    private float viewOffsetX = 0.3f;
    private float viewOffsetY = 0.1f;

    private const float fireInterval = 0.2f; // ���˂���܂ł̒���������
    private const float srowFireRate = 0.1f; // ���ˊԊu
    private float fireTimer = -fireInterval; // �����l��fireInterval�����炵�Ă���

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // �������甭�˂��邽�߂̕␳�ł��B

    private Animator animator; // �����̃A�j���[�^�[�R���|�[�l���g
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject; // ����Ōl�����J�ł��邩��
        cameraComponent = Camera.main; // �J�����R���|�[�l���g�擾
        animator = GetComponent<Animator>();
        SetStatusFromData();
    }

    private void SetStatusFromData()
    {
        // Static�N���X���玩���̃f�[�^���擾
        // ����͂����܂ł��e�X�g
        BattleTeam.sParentDragonData = new TestDragonStatus("0,10,1,3,4,5,6");
        playerStatus = BattleTeam.sParentDragonData;
        hitPoint = playerStatus.hp;
        speed = playerStatus.speed;
        attack = playerStatus.attack;
    }

    // Update is called once per frame
    void Update()
    {
        //���X�e�B�b�N
        Vector2 speedVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
 
        //Debug.Log("H" + Input.GetAxis("Horizontal"));
        //Debug.Log("V" + Input.GetAxis("Vertical"));

        //Debug.Log($"{speedVec}, {fadeSpeed}");
        Move(speedVec, speed);

        // �X�y�[�X�L�[�Œe�𔭎�
        // ����͋����đ����r�[�����o��
        // ���������Ă���ƍL�͈͂ɍL���鉊���o��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �����̌��݈ʒu�ɒe�̃v���n�u������
            GameObject bullet = Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
            // �����̍U���͂���悹
            bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
        }
        if (Input.GetKey(KeyCode.Space)) // Space�L�[��������
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > srowFireRate) // fireRate�b�Ɉ�񉊂����˂����
            {
                GameObject bullet = Instantiate(playerFireBullet, transform.position + instanceOffset, Quaternion.identity);
                // �����̍U���͂���悹
                bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
                fireTimer = 0; // �^�C�}�[���Z�b�g
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) // �L�[�𗣂�����
        {
            fireTimer = -fireInterval; // fireTimer�̏����l��fireInterval�����炵�Ă���
        }

        // �R���g���[���[
        if (Input.GetKeyDown("joystick button 0")) // A(��)�{�^���Ńr�[��
        {
            // �����̌��݈ʒu�ɒe�̃v���n�u������
            GameObject bullet = Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
            // �����̍U���͂���悹
            bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
        }
        if (Input.GetKey("joystick button 0")) // A(��)�{�^����������
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > srowFireRate) // fireRate�b�Ɉ�񉊂����˂����
            {
                GameObject bullet = Instantiate(playerFireBullet, transform.position + instanceOffset, Quaternion.identity);
                // �����̍U���͂���悹
                bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
                fireTimer = 0; // �^�C�}�[���Z�b�g
            }
        }

        if (Input.GetKeyUp("joystick button 0")) // �{�^���𗣂�����
        {
            fireTimer = -fireInterval; // fireTimer�̏����l��fireInterval�����炵�Ă���
        }
    }

    private void Move(Vector2 speedVec, float speed) // �ړ��\����Ƃ����l�ߍ���
    {
        // �܂��P�ʃx�N�g����
        Vector2 generalVec = speedVec.normalized;
        // �֐��ŕ�����g���`��ϐ��Ƃ��Đ錾
        float speedX = generalVec.x * speed * Time.deltaTime;
        float speedY = generalVec.y * speed * Time.deltaTime;
        // �����̍��W���J��������o�Ȃ��悤�ɐ���
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);

        // �z������߂�
        if (viewPos.x + viewOffsetX < 1.0f && speedX > 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.x - viewOffsetX > 0f && speedX < 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.y + viewOffsetY < 1.0f && speedY > 0)
        {
            transform.Translate(0f, speedY, 0f);
        }
        if (viewPos.y - viewOffsetY > 0f && speedY < 0)
        {
            transform.Translate(0f, speedY, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        if (temp.CompareTag("Enemy") || temp.CompareTag("Boss")) // �G�ɓ���������
        {
            Damage(collision.GetComponent<Enemy>().attack);
        }
        else if (temp.CompareTag("EnemyBullet"))
        {
            Damage(collision.GetComponent<EnemyBullet>().attack);
        }
    }

    private void Damage(int attack) // hitPoint�͂������猸�炷����
    {
        DamageNumberGenerator.GenerateText(attack, transform.position, Color.red);
        hitPoint -= attack;
        if (hitPoint > 0) // �����Ă�����
        {
            StartCoroutine(Blinking(4, 0.05f)); // �_��
        }
        else // �łȂ����
        {
            animator.SetTrigger("Death"); // ���b���[�V�������Đ�
        }
    }

    IEnumerator Blinking(int count, float interval) // interval�͕b�P��
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color visibleColor = new Color(255, 255, 255, 255);
        Color invisibleColor = new Color(255, 255, 255, 0);
        for (int i = 0; i < count; i++) // count��J��Ԃ�
        {
            spriteRenderer.color = invisibleColor;
            yield return new WaitForSeconds(interval); // interval�b�҂�
            spriteRenderer.color = visibleColor;
            yield return new WaitForSeconds(interval); // ����Ȃ���Ł@�ǂ��ł��傤
        }
    }
}
