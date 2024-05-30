# Legend-of-Sparta

[작업 과정]

1. 초기 맵 생성

2. 플레이어 InputSystem 구현

3. 3인칭 시점 구현
   
   ![image](https://github.com/amor1523/Legend-of-Sparta/assets/167174802/3d930739-7926-4803-a2b0-faa09dbb754e)

   ![image](https://github.com/amor1523/Legend-of-Sparta/assets/167174802/b50b3107-7727-446f-ba38-a5772b8f8a7a)

3인칭 시점을 구현하려고 카메라의 Offset을 설정해주었고, 좌우는 플레이어 기준, 상하는 카메라기준으로 돌려야겠다고 생각했다.

<트러블 슈팅>

처음에는 Camera를 Player의 자식 오브젝트로 두지 않고 독립적으로 두었고,
Camera의 Offset을 CameraLook 함수에 넣어 구현하니까 회전이 원하는대로 구현되지 않았다.

CameraController 스크립트를 만들어 Start에서 Offset을 넣어 분리해주었고, 카메라를 Player의 자식으로 두었다.

좌우 시점의 경우는 문제가 없었으나 상하 시점을 변경할 때는 CameraContainer 안에 Camera를 넣어 CameraContainer를 회전시켜주었다. (위아래 시점변경의 경우 플레이어 주변의 궤도를 도는 위성처럼 효과를 내었다.)

5. 인게임 UI 구현

6. 아이템 데이터 및 아이템 구현

<트러블 슈팅>

Interactio을 구현 중 3인칭이다 보니 타겟팅이 이상하게 되는 현상 발견
Player 중심에서 Ray를 쏴주려고 했으나 시점에 따른 원만한 타겟팅이 어려워 계획 변경
기존 방법에서 MaxCheckDistance의 수치를 높여주었더니 타겟팅이 잘 되었다.

![image](https://github.com/amor1523/Legend-of-Sparta/assets/167174802/f9f38d5c-4e83-426c-872a-1bec989e9966)

<트러블 슈팅...>
중간에 Soda Object에 PromptText가 NullException이 뜨는 문제 발생...
스크립트가 2개 들어가있었다...

ray가 적중했을 때 아웃라인도 넣기
해보려그랬는데 과제제출까지 작성을 못해서 튜터님께 조언을 구해 알아보기로 함.

7. 아이템 사용 구현

8. 점프대 구현

![image](https://github.com/amor1523/Legend-of-Sparta/assets/167174802/ead796ba-6ea2-4750-9b9e-e692cade5967)
