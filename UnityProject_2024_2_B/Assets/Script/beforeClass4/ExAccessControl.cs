//using system.collections;
//using system.collections.generic;
//using unityengine;

//public class exaccesscontrol : monobehaviour
//{
//    //public으로 선언된 변수는 다른 스크립트에서 직접 접근 가능
//    public int publicvalue;

//    //private로 선언된 변수는 같은 클래스 내에서만 접근 가능
//    private int privatevalue;

//    //protected로 선언된 변수는 같은 클래스 및 파생 클래스에서 접근 가능
//    protected int protectedvalue;

//    //internal로 선언된 변수는 같은 어셈블리(프로젝트 내 다른 스크립트) 내에서 접근 가능
//    internal int internalvalue;

//}

//public class parentclass
//{

//    private int protectedvalueparent;
//}

//public class childclass : parentclass //parentclass 상속
//{

//    void start()
//    {
//        debug.log(protectedvalueparent);

//    }

//}
