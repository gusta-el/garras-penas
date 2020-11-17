using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Subclasses
[System.Serializable]
public class Speed
{
    public float run;
    public float walk;
}

#region Prince Class
public class Prince
{
    private bool _isHuman;
    private bool _isMoving;
    private bool _isAttacking;
    private bool _isDead;
    private int _dialogSequence;

    public Prince(bool isHuman, bool isMoving, bool isAttacking, bool isDead, int dialogSequence)
    {
        _isHuman = isHuman;
        _isMoving = isMoving;
        _isAttacking = isAttacking;
        _isDead = isDead;
        _dialogSequence = dialogSequence;
    }

    public bool IsHuman { get => _isHuman; set => _isHuman = value; }
    public bool IsMoving { get => _isMoving; set => _isMoving = value; }
    public bool IsAttacking { get => _isAttacking; set => _isAttacking = value; }
    public bool IsDead { get => _isDead; set => _isDead = value; }
    public int DialogSequence { get => _dialogSequence; set => _dialogSequence = value; }

}
#endregion

#endregion

public class PlayerMotor : MonoBehaviour
{
    #region Instances
    public Prince prince;
    private SpriteRenderer playerSprite;
    private Animator animator;
    private PolygonCollider2D polygon;
    private Transform arvoreTransform;
    public Transform riverTransform;
    [SerializeField]
    private DialogueManager dialogueManager;

    #endregion

    #region Variables
    public float _speed;
    private int _lookAt = 2;
    public Speed speed;
    #endregion

    #region TAGs
    private string TAG_ARVORE = "arvore";
    private string TAG_river = "river";
    #endregion Variables

    #region AudioSources
    [SerializeField]
    private AudioSource walk;
    [SerializeField]
    private AudioSource flying;
    [SerializeField]
    private AudioSource attacking;
    #endregion

    private float spawn1_x;
    private float spawn1_y;
    private float spawn2_x;
    private float spawn2_y;

    void Start()
    {
        prince = new Prince(true, false, false, false, 0);
        playerSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        polygon = GetComponent<PolygonCollider2D>();
        arvoreTransform = GameObject.FindGameObjectWithTag(TAG_ARVORE).transform;
        riverTransform = GameObject.FindGameObjectWithTag(TAG_river).transform;    
    }

    void Update()
    {
        UpdatePrinceActions();
        Move();
        Attack();
    }

    void LateUpdate()
    {
        spawn1_x = riverTransform.position.x;
        spawn1_x = riverTransform.position.y;
        spawn2_x = riverTransform.position.x;
        spawn2_x = riverTransform.position.y;

        Vector3 riverPosition = riverTransform.position;
    }

    private void UpdatePrinceActions()
    {
        if (!prince.IsDead)
        {
            prince.IsMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
            prince.IsHuman = !Input.GetKey(KeyCode.LeftShift);
            prince.IsAttacking = Input.GetKey(KeyCode.Z);
        }
    }

    void Move()
    {
        //pega os inputs de horizontal e vertical predefinidos pela unity retornando um valor positivo ou negativo
        float _movX = Input.GetAxisRaw("Horizontal");
        float _movY = Input.GetAxisRaw("Vertical");
        
        _speed = prince.IsHuman ? speed.walk : speed.run;
    
        Vector3 velocity = new Vector3(_movX, _movY, 0) * Time.deltaTime * _speed;

        //seta a ação do jogador como andando caso uma tecla de movimentação esteja sendo precionada
        animator.SetBool("Walking", _movX != 0 || _movY != 0);
        animator.SetBool("transform", _speed > speed.walk);

        /*realiza a movimentação do jogador dependendo da direção olhada e da velocidade
        0 = Norte, 05 = Noroeste, 1 = Oeste, 15 = Suldoeste, 2 = Sul, 25 = Suldeste, 3 = Leste, 35 = Nordeste*/
        if (velocity.y > 0 && velocity.x == 0) _lookAt = 0;
        else if (velocity.x < 0 && velocity.y > 0) _lookAt = 5;
        else if (velocity.x < 0 && velocity.y == 0) _lookAt = 1;
        else if (velocity.x < 0 && velocity.y < 0) _lookAt = 15;
        else if (velocity.y < 0 && velocity.x == 0) _lookAt = 2;
        else if (velocity.x > 0 && velocity.y < 0) _lookAt = 25;
        else if (velocity.x > 0 && velocity.y == 0) _lookAt = 3;
        else if (velocity.x > 0 && velocity.y > 0) _lookAt = 35;

        animator.SetInteger("lookAt", _lookAt);

        transform.position += velocity;

        PlayMoveSounds(_movX, _movY);

    }

    void Attack()
    {
        if (prince.IsHuman && prince.IsAttacking)
        {
            attacking.Play();
        }
    }

    private void PlayMoveSounds(float _movX, float _movY)
    {
        if(prince.IsMoving && prince.IsHuman)
        {
            if (!walk.isPlaying)
            {
                walk.Play();
                flying.Stop();
            }
        } else if (prince.IsMoving)
        {
            if (!flying.isPlaying)
            {
                flying.Play();
                walk.Stop();
            }
        } else
        {
            walk.Stop();
            flying.Stop();

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("river"))
        {
            playerSprite.enabled = false;
            _speed = speed.walk;
            prince.IsDead = true;
        }

        if (!dialogueManager.IsActive)
        {
            if (col.CompareTag("dialog_fight_box") && !dialogueManager.IsActive)
            {
                Debug.Log("PASSEI");
                dialogueManager.StartDialog(prince.DialogSequence);
                prince.DialogSequence++;
            }


        }




    }

}
