using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region ==================== Locomotion
    // Move
    public Vector3 MoveDir { get; private set; }

    // Rotate
    public Vector2 MouseDir { get; private set; }
    public bool IsFlash { get; private set; }
    public bool IsMapScan {  get; private set; }
    public bool IsInteraction { get; private set; }
    #endregion ================= /Locomotion

    private void Update()
    {
        HandleMovementInput();
        HandleRotateMouseInput();

        IsFlash = Input.GetMouseButtonDown(0);
        IsMapScan = Input.GetKeyDown(KeyCode.C);
        IsInteraction = Input.GetKeyDown(KeyCode.F);
    }

    private void HandleMovementInput()
    {
        MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));   // 0 ~ 1

        // 대각선 보정, 조이스틱같은 컨트롤러 방향 힘(민감도)도 보존하기 위해 대각선 힘 1넘었을때만 정규화
        if (MoveDir.magnitude > 1f) MoveDir.Normalize();
    }

    private void HandleRotateMouseInput()
    {
        MouseDir = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

}
