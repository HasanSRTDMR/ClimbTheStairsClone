using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    [SerializeField] ParticleSystem[] PlayerParticles;
    [SerializeField] Color[] _playerColor;
    [SerializeField] UIManager uIManager;
    Material playerMat;
    [HideInInspector] public float stamina;
    public static float startStamina = 20;
    public static float maxStaminaValue = 10;
    void OnEnable()
    {
        EventManager.MousePressEvent += RunAnimation;
        //EventManager.MousePressEvent += PlayPlayerSound;
        EventManager.MousePressEvent += StaminaController;

    }
    void OnDisable()
    {
        EventManager.MousePressEvent -= RunAnimation;
        //EventManager.MousePressEvent -= PlayPlayerSound;
        EventManager.MousePressEvent -= StaminaController;
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerParticles[0].Stop();
        PlayerParticles[1].Stop();
        animator = GetComponent<Animator>();
        playerMat = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;
        if (Data.HaveRecord("StartStamina"))
            startStamina = Data.GetStartStamina();
        if (Data.HaveRecord("MaxStamina"))
            maxStaminaValue = Data.GetMaxStamina();

            stamina = startStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.playGame)
        {
            if (Input.GetMouseButton(0))
            {
                DecreaseStamina();
            }
            else
            {
                RaiseStamina();
            }
        }
       
    }
    private void RunAnimation()
    {
        animator.SetBool("Run", true);
    }
    public void IdleAnimation()
    {
        animator.SetBool("Run", false);
    }
    private void RunSweatingAnim()
    {
        PlayerParticles[0].Play();
    }

    private void StopSweatingAnim()
    {
        PlayerParticles[0].Stop();
    }
    private void Blushing(Color color, float duration)
    {
        playerMat.DOColor(color, duration);
    }
    private void ShapeShifting()
    {
        transform.DOScale(0.8f, 0.2f).SetEase(Ease.OutBounce).OnComplete(() => transform.DOScale(0.7f, 0.2f));
    }
    public void RaiseStamina()
    {

        Blushing(_playerColor[0], 10f);

        if (stamina > 7 && stamina < maxStaminaValue)
        {
            StopSweatingAnim();
            stamina += Time.deltaTime;
        }
        else if (stamina <= 7 && stamina >= 2)
        {
            stamina += Time.deltaTime / 2;
        }
        else if (stamina < 2 && stamina > 0)
        {
            stamina += Time.deltaTime / 4;
        }

        //stamina = Mathf.Min(stamina, maxStaminaValue);
    }

    private void DecreaseStamina()
    {
        stamina -= Time.deltaTime;
        stamina = Mathf.Max(stamina, 0);
    }

    private void StaminaController()
    {
        if (stamina <= 7 && stamina > 2)
        {
            RunSweatingAnim();
        }
        else if (stamina <= 2 && stamina > 0)
        {
            Blushing(_playerColor[1], stamina / 2);
            ShapeShifting();
        }

        else if (stamina <= 0)
        {
            Die();
            
        }
        Debug.Log(stamina);
    }

    private void Die()
    {
        PlayerParticles[1].Play();
        gameObject.SetActive(false);
        uIManager.OpenLosePanel();
    }
   
    public void Resume()
    {
        stamina = maxStaminaValue;
        StopSweatingAnim();
        PlayerParticles[1].Stop();
    }

}
