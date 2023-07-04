using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

// IPunOwnershipCallbacksを追加
public class DestroyNetworkObject : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    GameObject clickedObj;

    private void Start() {
        PhotonNetwork.NickName = "Player";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom() {
        // ランダムな位置にネットワークオブジェクトを生成する
        var position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("Object", position, Quaternion.identity);
    }

    private void Update()
    {
        // オブジェクトがクリックされた時にDestroyObjを呼び出す
        if (Input.GetMouseButtonDown(0))
        {
            clickedObj = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hitSprite = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hitSprite == true)
            {
                clickedObj = hitSprite.transform.gameObject;
                DestroyObj(clickedObj);
            }
        }
    }

    private void DestroyObj(GameObject obj)
    {
        obj.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
    }
    // IPunOwnershipCallbacks.OnOwnershipTransferedを実装
    void IPunOwnershipCallbacks.OnOwnershipTransfered(PhotonView targetView, Player previousOwner) 
    {
        // ネットワークオブジェクトを削除
        PhotonNetwork.Destroy(targetView.gameObject);
    }

    // 以下のメソッドも実装しないとエラーが出る
    void IPunOwnershipCallbacks.OnOwnershipTransferFailed(PhotonView targetView, Player previousOwner)
    {

    }

    void IPunOwnershipCallbacks.OnOwnershipRequest(PhotonView targetView, Player requestingPlayer) 
    {

    }
}