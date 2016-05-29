using UnityEngine;
using System.Collections;
public class UIPhoneManagerScript : MonoBehaviour {
	public Animator btn1;
	public Animator btn2;
	public Animator btn3;
	public Animator btn4;
	public Animator btn5;
	public Animator btn6;
	public Animator btn7;
	public Animator btn8;
	public Animator btn9;
	public Animator btn_custom1;
	public Animator btn_custom2;
	public Animator btn_custom3;
	private AudioClip[] clips;
	public AudioClip[] clips1;
	public AudioClip[] clips2;
	public AudioClip[] clips3;
	public AudioClip callRing;
	// Use this for initialization
	public float timeRemaining = 60f;
	enum GameType {NUM, MUSIC,ANIMAL};
	public AudioSource source;
	private bool playNow = false;
	private bool playCall = false;
	private int playCallFinish = 0;
	private int cnt =0;
	private int scene =1;
	private bool isLoaded =false;
	public GameObject[] num;
	public GameObject[] music;
	public GameObject[] animals;
	private GameObject[] arrObj;
	private GameType gameType=GameType.NUM;
	GameObject showingObj;

	public GameObject[] gamePlays;
	private GameObject game;
	public GameObject[] bgs;
	private GameObject bg;
	public GameObject[] bgPhones;
	private GameObject bgPhone;
	private AudioClip bgClip;
	private string[] fileBGClips= new string[]{"sounds/numbers","sounds/notas","sounds/animals"};
	void Start () {
		InvokeRepeating ("increaseTimeRemaining", 1.0f, 1.0f);
//		RequestBanner ();
//		UM_AdManager.instance.CreateAdBanner(TextAnchor.UpperCenter);
		isLoaded = false;
		changeGameType (GameType.NUM);
	}
	void changeGameType(GameType type)
	{
		gameType = type;
		Debug.Log ("gameType=" + gameType);
		if (game) {
			DestroyObject(game);
		}
		if (bg) {
			DestroyObject(bg);
		}
		if (bgPhone) {
			DestroyObject(bgPhone);
		}
		int i = 0;
		if (gameType == GameType.NUM) {
			i=0;
			clips = clips1;
			arrObj = num;
		} else if (gameType == GameType.MUSIC) {
			i=1;
			clips = clips2;
			arrObj = music;

		} else {
			i=2;
			clips = clips3;
			arrObj = animals;
		}
		source.Stop ();
		bgClip = Resources.Load(fileBGClips[i], typeof(AudioClip)) as AudioClip;
		source.PlayOneShot (bgClip);
		game = Instantiate(gamePlays[i]);
		bg = Instantiate(bgs[i]);
		bgPhone = Instantiate(bgPhones[i]);

		bg.SetActive (true);
		bgPhone.SetActive (true);
		game.SetActive (true);
		Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		game.transform.SetParent(canvas.transform, false);
		int index = Random.Range (0, num.Length - 1);
		playWithIndex (index);

	}
	void Awake () {
		Debug.Log ("Awake UIPhoneManage");
//		UM_AdManager.instance.Init();
		
	}
	// Update is called once per frame
	void Update () {
		if (!isLoaded &&Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
			return;
		}
		if (timeRemaining % 3 == 0)
		{
			wiggleButton();
		}
		if (playNow == true) {
			PlaySounds();
		}
		if(!isLoaded && Application.loadedLevel != scene){
			
			if (Application.CanStreamedLevelBeLoaded(scene)) {
				Application.LoadLevelAdditiveAsync (scene);
			}
			isLoaded=true;
		}
	}
	void PlaySounds(){
		if(!source.isPlaying && cnt < clips.Length){
			int index = Random.Range(0,8);
			source.clip = clips[index];
			wiggleBtn(index);
			source.Play();
			cnt = cnt + 1;
		}
		if (cnt == clips.Length) {
			cnt = 0;
			playNow=false;
			btnCallClicked();
		}
	}
	void increaseTimeRemaining()
	{
		timeRemaining ++;
	}
	public void btnCallClicked()
	{
		scene = 2;
		source.Stop ();
		source.PlayOneShot(callRing);
//		AsyncOperation async= Application.LoadLevelAdditiveAsync ("PhoneDetail");
//		yield async;
//		playCall = true;
//		source.clip = callRing;
//		source.Play ();

	}
	public void wiggleButton()
	{
		for (int i=0; i<9; i++) {
//			wiggleBtn(i);
		}
	}
	private void wiggleBtn(int i){
		if (i == 0) {
			bool isHidden = btn1.GetBool ("isPlay");
			btn1.SetBool ("isPlay", !isHidden);
		} else if (i == 1) {
			bool isHidden = btn2.GetBool ("isPlay");
			btn2.SetBool ("isPlay", !isHidden);
		} else if (i == 2) {
			bool isHidden = btn3.GetBool ("isPlay");
			btn3.SetBool ("isPlay", !isHidden);
		} else if (i == 3) {
			bool isHidden = btn4.GetBool ("isPlay");
			btn4.SetBool ("isPlay", !isHidden);
		} else if (i == 4) {
			bool isHidden = btn5.GetBool ("isPlay");
			btn5.SetBool ("isPlay", !isHidden);
		} else if (i == 5) {
			bool isHidden = btn6.GetBool ("isPlay");
			btn6.SetBool ("isPlay", !isHidden);
		} else if (i == 6) {
			bool isHidden = btn7.GetBool ("isPlay");
			btn7.SetBool ("isPlay", !isHidden);
		} else if (i == 7) {
			bool isHidden = btn8.GetBool ("isPlay");
			btn8.SetBool ("isPlay", !isHidden);
		} else if (i == 8) {
			bool isHidden = btn9.GetBool ("isPlay");
			btn9.SetBool ("isPlay", !isHidden);
		} else if (i == 9) {
			bool isHidden = btn_custom1.GetBool ("isPlay");
			btn_custom1.SetBool ("isPlay", !isHidden);
		} else if (i == 10) {
			bool isHidden = btn_custom2.GetBool ("isPlay");
			btn_custom2.SetBool ("isPlay", !isHidden);
		} else if (i == 11) {
			bool isHidden = btn_custom3.GetBool ("isPlay");
			btn_custom3.SetBool ("isPlay", !isHidden);
		}
	}
	public void btn2Clicked()
	{
		playWithIndex (1);
	}
	public void btn3Clicked()
	{
		playWithIndex (2);
	}
	public void btn4Clicked()
	{
		playWithIndex (3);
	}
	public void btn5Clicked()
	{
		playWithIndex (4);
	}
	public void btn6Clicked()
	{
		playWithIndex (5);
	}
	public void btn7Clicked()
	{
		playWithIndex (6);
	}
	public void btn8Clicked()
	{
		playWithIndex (7);
	}
	public void btn9Clicked()
	{
		playWithIndex (8);
	}
	public void btn1Clicked()
	{
		playWithIndex (0);
	}
	public void btnLeftClicked()
	{
		if (gameType == GameType.NUM) {
			changeGameType (GameType.MUSIC);
		} else if (gameType == GameType.MUSIC) {
			changeGameType (GameType.ANIMAL);
		} else {
			changeGameType (GameType.NUM);
		}
		Handheld.Vibrate();
	}
	public void btnRightClicked()
	{
		if (gameType == GameType.NUM) {
			changeGameType(GameType.ANIMAL);
		}else if (gameType == GameType.MUSIC) {
			changeGameType (GameType.NUM);
		} else {
			changeGameType (GameType.MUSIC);
		}
		Handheld.Vibrate();
	}
	void playWithIndex(int i)
	{
		if (showingObj)
			DestroyObject (showingObj);
		showingObj = Instantiate (arrObj[i]);
		showingObj.gameObject.SetActive (true);
		source.PlayOneShot (clips[i]);
		Handheld.Vibrate();
	}
}
