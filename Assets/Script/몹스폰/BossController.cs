using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour,IDamageable
{
    

    public int AttackPower;
    public bool IsAlive { get; private set; } = true;
    public float maxHealth;
    public float attackPreparationTime = 30f;
   

    private float currentHealth;
    private int currentPhase = 1;
    private float phaseHealthLimit;  // �� ������� ü�� �ѵ�
    private float attackTimer;
    SpriteRenderer spriteRenderer;
    BossSpawner bossSpawner;
    private void Start()
    {
        bossSpawner = GetComponent<BossSpawner>();
        currentHealth = maxHealth;
        phaseHealthLimit = maxHealth/3;
        attackTimer = attackPreparationTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            BaseHealth baseHealth = FindObjectOfType<BaseHealth>();
            baseHealth.TakeDamage(AttackPower);  // 50�� ������ ���ݷ��� ��Ÿ���� ���� ���Դϴ�.
            attackTimer = attackPreparationTime;  // Ÿ�̸� ����
        }

        // ü���� �ѵ� ���Ϸ� �������ų� ���� �غ� �ð��� ������ ���� ������� ��ȯ
        
    }

    public void TakeDamage(float damage)
    {
        if (this == null || gameObject == null)
            return;
        currentHealth -= damage;
        float healthLost = maxHealth - currentHealth;

        if (healthLost >= 5000 || attackTimer <= 0)
        {
            // ü�� ���ҿ� ���� ������ ��ȯ ���� �߰�
            if (currentPhase == 1 && healthLost >= 5000)
            {
                NextPhase();
            }
            else if (currentPhase == 2 && healthLost >= 10000)
            {
                NextPhase();
            }
            else if (attackTimer <= 0 && currentPhase < 3) // ������ ��������� attackTimer�� 0�̵Ǿ NextPhase�� ȣ������ ����
            {
                NextPhase();
            }
        }
        Debug.Log("��������ü��:" + currentHealth);
        // ���� ü���� 0 ���Ϸ� �������� �� ó��
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            // ���� ���� �Ǵ� ���� ����/é�� ���� �߰�
        }
    }

    private void NextPhase()
    {
        bossSpawner = GetComponent<BossSpawner>();
        currentPhase++;
        switch (currentPhase)
        {
            case 1: break;

            case 2:
                Debug.Log("Phase2");
                transform.position = new Vector3(8f,0f,0);
                spriteRenderer.flipX = false; // Flip to face right
                spriteRenderer.flipY = false;
                transform.rotation = Quaternion.Euler(0, 0, 0); // Reset rotation
                break;

            case 3:
                Debug.Log("Phase3");
                transform.position = new Vector3(0f, 4.0f, 0);
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = false;
                transform.rotation = Quaternion.Euler(0, 0, 90); // Rotate to face downward
                break;
        }

        switch (currentPhase)
        {
            case 1:break;
            case 2: Debug.Log("Case2");break;
            case 3:Debug.Log("Case3");
                break; ;
        }

        if (currentPhase > 3)
        {
            // ������ �� �� �������� �� ó��
            Destroy(gameObject);
            // ���� ���� �Ǵ� ���� ����/é�� ���� �߰�
            return;
        }

        attackTimer = attackPreparationTime;
        // �ٸ� ������ ��ȯ ���� (��: �ִϸ��̼�, ���� ���� ���� ��)
    }
}
