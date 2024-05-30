# Legend-of-Sparta

[작업 과정]

1. 초기 맵 생성

2. 플레이어 InputSystem 구현

3. 3인칭 시점 구현
   
   ![image](https://github.com/amor1523/Legend-of-Sparta/assets/167174802/3d930739-7926-4803-a2b0-faa09dbb754e)

   ![image](https://github.com/amor1523/Legend-of-Sparta/assets/167174802/b50b3107-7727-446f-ba38-a5772b8f8a7a)

3인칭 시점을 구현하려고 카메라의 Offset을 설정해주었고, 좌우는 플레이어 기준, 상하는 카메라기준으로 돌려야겠다고 생각했다.

<트러블 슈팅>
Camera의 Offset을 CameraLook 함수에 넣어 구현하니까 회전이 원하는대로 구현되지 않았다.
CameraController 스크립트를 만들어 Start에서 Offset을 넣어 분리해주었고,
좌우 시점의 경우는 문제가 없었으나 상하 시점을 변경할 때는 CameraContainer 안에 Camera를 넣어 CameraContainer를 회전시켜주었다.
(위아래 시점변경의 경우 플레이어 주변의 궤도를 도는 위성처럼 효과를 내었다.)

5. 인게임 UI 구현

6. 
