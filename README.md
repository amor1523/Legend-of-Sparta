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

먼저 CameraContainer 오브젝트를 만들고 카메라를 Player의 자식으로 두었다.

좌우 시점의 경우는 문제가 없었으나 상하 시점을 변경할 때는 CameraContainer 안에 Camera를 넣어 CameraContainer를 회전시켜주었다. (위아래 시점변경의 경우 플레이어 주변의 궤도를 도는 위성처럼 효과를 내었다.)

마지막으로 Offset은 Main Camera의 Transform Position을 (0, 2, -6)으로 직접 설정해주었다.

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

ray가 적중했을 때 오브젝트에 아웃라인도 넣기
강의에서 들은 내용으로 Outline을 구현하려고 했으나 Outline 컴포넌트는 UI 속성이기 때문에 아무리 해도 구현되지 않았던 것...
이를 구현하려면 Shader로 구현을 하기위해 Unlit Graph(3D에서 빛에 반응하지 않는 그래프를 만들 때)를 사용해야함...

Window > Package Manager> Packages: Unity resistry에서 universal RP를 Install해준 뒤
프로젝트창에서에서 Creat > Rendering > URP Universal Render 를 하면 파일이 생성된다.
(New Custom Universal Renderer Data)

Edit > Project setting > Graphics 에서 Scriptable Render Pipeline Settings의 None을 생성한 파일로 바꿔준다.

edit > render pipeline > universal render pipeline > upgrade project meterials ... 

Project 창 Shader폴더 Create - Shader Graph - URP - Unlit Shader Graph 를 생성해주고 값을 설정했다.

기존 파일들이 다 분홍색으로 처리되어 추후 URP로 프로젝트 진행 시 진행해보자...


[쉐이더 참고] 
https://www.youtube.com/watch?v=KnueAgpUL3Y&t=495s
https://www.youtube.com/watch?v=Bm6Bmcjd1Mw

7. 아이템 사용 구현

8. 점프대 구현

![image](https://github.com/amor1523/Legend-of-Sparta/assets/167174802/ead796ba-6ea2-4750-9b9e-e692cade5967)


FeedBack

김명민 튜터 ・ 24.05.29(수)

- 필수 요구사항 및 3인칭 시점 카메라를 잘 구현해주셨습니다. 구현하시면서 고민하셨던 흔적이 트러블슈팅에 잘 드러나 있는 것 같아 좋았습니다.

- URP는 프로젝트를 진행 중에 바꾸는 것보다는 애초에 프로젝트를 생성할 때 URP를 선택해서 진행해주는 것이 마음 편하긴 합니다. 렌더링 방식 자체가 완전 달라지는 것이기 때문에 머테리얼이나 셰이더가 호환이 안 되는 경우가 많습니다 ㅠㅠ 에셋 스토어 등에서 외부 에셋을 가져올 때도, 현재 프로젝트의 렌더 파이프라인과 호환되는 에셋인지 항상 잘 확인해보아야 합니다.

- 현재 3인칭 시점에서 Interaction Ray를 카메라 기준으로 생성하고 있습니다. 이렇게 되면 캐릭터의 뒤 - 카메라 사이에 있는 오브젝트도 Ray를 통해 검출되어 캐릭터가 뒤돌아 있는 상태에서도 상호작용이 가능하게 되는 문제가 생깁니다. DrawRay를 통해 씬뷰에 표시되는 Ray를 확인해봤을 때도 이를 확인할 수 있습니다. 카메라가 아니라 캐릭터가 바라보고 있는 정면을 기준으로 상호작용을 위한 Ray를 생성하는 로직으로 처리하는 것이 조금 더 자연스러워 보입니다.

- 깃허브의 커밋 내역에 ‘Update README.md’가 여러 번 반복해서 나타나는 부분이 있습니다. Squash를 통해 하나의 커밋으로 합쳐주면 커밋 내역을 조금 더 깔끔하게 관리할 수 있습니다.

- 개인 과제 고생 많으셨습니다. 팀 프로젝트도 화이팅입니다!
