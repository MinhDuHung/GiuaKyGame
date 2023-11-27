using System.Collections;
using UnityEngine;

public class FlyingEyeMove : MonoBehaviour
{
    public float speed = 5f;
    public float attackRange = 1.5f;
    public Animator playerAnim;
    CharacterStat character;
    public Animator animator;
    private Transform player;
    private float atkWait = 0f;
    float rootAtkWait = 2.5f;

    void Start()
    {
        atkWait = rootAtkWait;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        character = FindFirstObjectByType<CharacterStat>();

        // Bắt đầu coroutine sinh ra quái thú sau mỗi 4 giây
        StartCoroutine(SpawnEnemyRoutine());
    }

    void Update()
    {
        // Nếu quái thú đang ở gần người chơi, thực hiện tấn công
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            AttackPlayer();
        }
        else
        {
            // Ngược lại, di chuyển tới vị trí của người chơi
            MoveTowardsPlayer();
        }

        // Cập nhật thời gian chờ giữa các lần tấn công
        atkWait += Time.deltaTime;
    }

    void MoveToRandomPosition()
    {
        // Chọn ngẫu nhiên giữa 4 vị trí được định trước
        float randomX = Random.Range(-10f, 10f);
        float randomY = Random.Range(-1f, 4f);

        // Đặt vị trí mới cho quái thú
        transform.position = new Vector2(randomX, randomY);
    }

    void MoveTowardsPlayer()
    {
        // Di chuyển tới vị trí của người chơi
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        // Kiểm tra điều kiện trước khi thực hiện tấn công
        if (atkWait >= rootAtkWait)
        {
            animator.SetFloat("atk", 1);
            character.getHitByEnermy(10);
            if (character.getHP() <= 0) Destroy(character.gameObject);
            playerAnim.SetBool("takeHit", true);
            atkWait = 0;
            Invoke("resetATK", 0.5f);
        }
    }

    void resetATK()
    {
        playerAnim.SetBool("takeHit", false);
        animator.SetFloat("atk", -1);
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Thực hiện logic để sinh ra quái thú ở vị trí mới
        MoveToRandomPosition();
    }
}
