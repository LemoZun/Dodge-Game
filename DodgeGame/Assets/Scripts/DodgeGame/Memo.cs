using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memo : MonoBehaviour
{
    //게임종료 이벤트 구현
    //게임시작 이벤트 구현

    //게임시작시 플레이어 위치 초기화
    //ㄴ 플레이어는 씬이 바뀌지 않는이상 항상 활성화상태로 있다
    //ㄴ 그럼 onenable과 ondisable에 이벤트 구독관리를 하는것보다 start와 ondestroy에서 해주는게 낫지 않을까?
    //rigid.velocity에 vector3.(0,0,0)을 대입하려했더니 안되서 ZERO로 했다
    //ㄴ 차이가 있다는건 알겠는데 정확히 모르겠네.. 인스펙터 상에선 velocity도 xyz값인 벡터3로 받는데
    //ㄴ new Vector3로 해주니 되긴 하는데 그럼 또 왜 Vector.zero는 되는거지? 이것도 new Vector3.zero 해야하는거 아닌가
    //ㄴ 이번엔 회전초기화는 이번엔 모델링이 단순해서 필요 없다
    //ㄴ 자동완성으로 rigid.rotation = Quaternion.identity; 가 나오는데 회전이니 쿼터니언 쓰는건 이해가 되는데 identity는 뭐지
    //ㄴ Quaternion.Euler 써야할줄 알았는데
    //게임 종료시 총알 다 사라짐

    // 게임 시작시 시간 누적    
    // best score 갱신

    // 피격되어 게임이 끝날경우 경과시간 기록x

    // 20초 경과시 클리어존 활성화
    //ㄴ 일단 시작시 바로 비활성화 시키면 되나
    // 20초 지나는건 코루틴? 근데 한번만 활성화 시킬건데 Time 쓰는거랑 뭐가 더 나을까
    // 클리어존 컨트롤러가 비활성화되면 스스로 활성화 시킬 수 없으니 객체를 따로 둬야겠다


    //프레임에 따라 경과시간이 변할 필요는 없으니 deltaTime 말고 그냥 Time을 써야할거같은데
    

}
