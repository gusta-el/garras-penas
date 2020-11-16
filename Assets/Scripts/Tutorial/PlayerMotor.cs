using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Speed
{
    public float dead;
    public float run;
    public float walk;
}

public class PlayerMotor : MonoBehaviour
{
    private bool dead;
    public float _speed;
    private int _lookAt = 2;
    public Speed speed;

    private Animator animator;
    private PolygonCollider2D polygon;

    private SpriteRenderer playerSprite;
    private Transform arvoreTransform;
    private string TAG_ARVORE = "arvore";

    public Transform riverTransform;
    private string TAG_river = "river";

    private float spawn1_x;
    private float spawn1_y;
    private float spawn2_x;
    private float spawn2_y;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        polygon = GetComponent<PolygonCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        arvoreTransform = GameObject.FindGameObjectWithTag(TAG_ARVORE).transform;
        riverTransform = GameObject.FindGameObjectWithTag(TAG_river).transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void LateUpdate()
    {
        spawn1_x = riverTransform.position.x;
        spawn1_x = riverTransform.position.y;
        spawn2_x = riverTransform.position.x;
        spawn2_x = riverTransform.position.y;

        Vector3 riverPosition = riverTransform.position;
    }
        void Move()
    {
        //pega os inputs de horizontal e vertical predefinidos pela unity retornando um valor positivo ou negativo
        float _movX = Input.GetAxisRaw("Horizontal");
        float _movY = Input.GetAxisRaw("Vertical");

        //altera a velocidade do jogador caso ele esteja precionando o shift esquerdo
        if (dead == false)
        {
            _speed = Input.GetKey(KeyCode.LeftShift) ? speed.run : speed.walk;
        }

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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("river"))
        {
            playerSprite.enabled = false;
            _speed = speed.walk;
            dead = true;
        }    
    }
}
