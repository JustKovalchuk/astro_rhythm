#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class MsgContext : global::System.IDisposable {
  private global::System.IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal MsgContext(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(MsgContext obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  internal virtual void setCPtr(global::System.IntPtr cPtr) {
    Dispose();
    swigCPtr = cPtr;
  }

  ~MsgContext() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_MsgContext(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public MsgContext(uint pId, ulong goId, uint nodeId, bool isBus) : this(AkSoundEnginePINVOKE.CSharp_new_MsgContext__SWIG_0(pId, goId, nodeId, isBus), true) {
  }

  public MsgContext(uint pId, ulong goId, uint nodeId) : this(AkSoundEnginePINVOKE.CSharp_new_MsgContext__SWIG_1(pId, goId, nodeId), true) {
  }

  public MsgContext(uint pId, ulong goId) : this(AkSoundEnginePINVOKE.CSharp_new_MsgContext__SWIG_2(pId, goId), true) {
  }

  public MsgContext(uint pId) : this(AkSoundEnginePINVOKE.CSharp_new_MsgContext__SWIG_3(pId), true) {
  }

  public MsgContext() : this(AkSoundEnginePINVOKE.CSharp_new_MsgContext__SWIG_4(), true) {
  }

  public uint in_playingID { set { AkSoundEnginePINVOKE.CSharp_MsgContext_in_playingID_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_MsgContext_in_playingID_get(swigCPtr); } 
  }

  public ulong in_gameObjID { set { AkSoundEnginePINVOKE.CSharp_MsgContext_in_gameObjID_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_MsgContext_in_gameObjID_get(swigCPtr); } 
  }

  public uint in_soundID { set { AkSoundEnginePINVOKE.CSharp_MsgContext_in_soundID_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_MsgContext_in_soundID_get(swigCPtr); } 
  }

  public bool in_bIsBus { set { AkSoundEnginePINVOKE.CSharp_MsgContext_in_bIsBus_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_MsgContext_in_bIsBus_get(swigCPtr); } 
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.