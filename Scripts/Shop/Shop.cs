using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public int currentSelectedItem;
    public int currentItemCost;
    public Text gemCountText;

    private Player _player;

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();

            if (_player != null)
            {
                UIManager.Instance.OpenShop(_player.diamonds);
            }

            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        Debug.Log("SelectItem() : " + item);

        switch (item)
        {
           case 0:
                UIManager.Instance.UpdateShopSelection(-46);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-141);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-246);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if (_player.diamonds >=currentItemCost)
        {
            if (currentSelectedItem==2)
            {
                GameManager.Instance.HasKeyToCastle=true;
            }

            _player.diamonds -= currentItemCost;
            Debug.Log("구입완료" + currentSelectedItem);
            Debug.Log("남은 보석" + _player.diamonds);
            gemCountText.text = "" + _player.diamonds;
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("돈이 없구나 가라");
            shopPanel.SetActive(false);
        }
    }

}
