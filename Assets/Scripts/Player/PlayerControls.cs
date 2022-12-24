using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float swipeDetectLength; //Ekrandaki kaydırmaya bağlı fonksiyonların ne kadar uzun kaydırınca tetikleneceğini belirler.
    int sizesArrayLength; //Karakterin boyutlarını tutan dizinin uzunluğunu tutar.
    ResizePlayer resizePlayer;
    PlayerMovement playerMovement;
    Vector3 firstTouchPosition; //Kaydırma başladığında ekranda ilk dokunulan pozisyonu tutar.
    float swipeLength; //Kaydırmanın ne kadar uzun olduğunu tutar.

    public bool inputReset; //Oyuncu engele çarptığında kontrol değerlerini sıfırlamak için kullandım.

    void Start()
    {
        resizePlayer = GetComponent<ResizePlayer>();
        playerMovement = transform.root.GetComponent<PlayerMovement>();
        sizesArrayLength = resizePlayer.resizeValues.size.GetUpperBound(0);
    }
    void Update()
    {
        transform.localPosition = Vector3.up * transform.localScale.y / 2; /*Karakterin boyutu değiştiğinde merkezden değişiyor.
        Y eksenini değiştirerek karakterin boyutunun alt bolgeden değişiyormuş gibi göstermek için */

        SwipeDetection();

        //Kaydırma uzunluğu yeterli ise VE şu anki boyutun indexi dizinin boyutundan küçük ise;
        if (swipeLength > swipeDetectLength && resizePlayer.currentSizeIndex < sizesArrayLength)
        {
            resizePlayer.currentSizeIndex++; //Karakterin boyutunun indexini arttır.
            ResetSwipe();
        }

        if (swipeLength < -swipeDetectLength && resizePlayer.currentSizeIndex > 0)
        {
            resizePlayer.currentSizeIndex--;
            ResetSwipe();
        }
    }
    void ResetSwipe()
    {
        swipeLength = 0; //Kaydırma uzunluğunu sıfırlar
        firstTouchPosition.x = Input.mousePosition.x; //ilk dokunulan bölgeyi tekrar belirler.
    }
    void SwipeDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!playerMovement.isRotating)
                playerMovement.dynamicMoveSpeed = 1; //Eğer dönüşte değil ise karakterin hareket ettirir

            firstTouchPosition.x = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            if (inputReset) //Karakter yandığında oyuncunun elini ekrandan çekip tekrar dokunmasını sağlamak için.
                playerMovement.dynamicMoveSpeed = 0;

            //Eğer dizinin son elemanındaysak ve oyuncu karakterin boyutunu değiştirmek için kaydırmaya devam ediyorsa kaydırma boyutunu sıfırlar.
            if ((resizePlayer.currentSizeIndex == sizesArrayLength && swipeLength > 0) || (resizePlayer.currentSizeIndex == 0 && swipeLength < 0))
            {
                ResetSwipe();
            }
            else
            {
                swipeLength = Input.mousePosition.x - firstTouchPosition.x; //Kaydırmanın uzunluğunu belirler.
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (!playerMovement.isRotating)
                playerMovement.dynamicMoveSpeed = 0; //Eğer dönüşte değil ise karakteri durdurur.

            swipeLength = 0f;
            inputReset = false;
        }
    }
}

