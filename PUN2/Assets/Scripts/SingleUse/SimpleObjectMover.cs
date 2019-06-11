using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectMover : MonoBehaviourPun,IPunObservable
{
    #region Public Variables*
    #endregion
    #region Private Variables
    #region Serialized Fields
    [SerializeField]
    private float _moveSpeed = 1f;
    #endregion
    private Animator _animator;
    #endregion
    #region Callbacks
    #region MonoBehaviour Callbacks
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (base.photonView.IsMine)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            transform.position += (new Vector3(x, y, 0f)) * _moveSpeed;//Could've just used transform.Translate but Nooo

            UpdateMovingBoolean(x != 0f || y != 0f);
        }
    }
    #endregion
    #region IPunObservable Callbacks(Commented)
    //called every 1/5 second as specified in the SerializationRate.
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        /* if (stream.IsWriting)
         {
             stream.SendNext(transform.position);
             stream.SendNext(transform.rotation);
         }
         else if (stream.IsReading)
         {
             transform.position = (Vector3)stream.ReceiveNext();
             transform.rotation = (Quaternion)stream.ReceiveNext();
         }*/
    }
    #endregion
    #region PUN Callbacks*
    #endregion
    #endregion
    #region Public Methods*
    #endregion
    #region Private Methods
    private void UpdateMovingBoolean(bool moving)
    {
        _animator.SetBool("Moving", moving);
    }
    #endregion
}
