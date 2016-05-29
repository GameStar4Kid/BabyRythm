using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManagePhoneDetailScript : MonoBehaviour {
	public AudioClip frog;
	public AudioClip horse;
	public AudioClip sheep;
	public AudioClip cow;
	public AudioClip duck;
	public AudioClip turkey;
	public AudioClip coat;
	public AudioClip chicken;
	public AudioClip dog;
	public Text text; 
	public Image image; 
		//songs
	public AudioClip[] clips;
	private string[] strings= new string[]{"Baa Baa Black Sheep","Yankee Doodle","Crooked Man","Five Little Duck","Grand Old Duke","Hickory Dickory Dock","If You Are Happy","I'm a Little Teapot","Incy Wincy Spider","Jack And Jill","London Bridge","Old Macdonald","Ride a Cock Horse To Course","Ring a Ring of Roses","Round And Round The Garden","Row Row Your Boat","This Old Man","Three Blind Mice","Tom The Pipers Son","Wheels On The Bus","Where Has My Dog Gone"};
	private string[] images2= new string[]{"Baa Baa Black Sheep","Yankee Doodle","Crooked Man","Five Little Duck","Grand Old Duke","Hickory Dickory Dock","If You Are Happy","Im a Little Teapot","Incy Wincy Spider","Jack And Jill","London Bridge","Old Macdonald","Ride a Cock Horse To Course","Ring a Ring of Roses","Round And Round The Garden","Row Row Your Boat","This Old Man","Three Blind Mice","Tom The Pipers Son","Wheels On The Bus","Where Has My Dog Gone"};
	private string[] clips2= new string[]{"baa_baa_black_sheep","yankee_doodle","crooked_man","five_little_ducks","grand_old_duke","hickory_dickory_dock","if_you_are_happy","im_a_little_teapot","incy_wincy_spider","jack_and_jill","london_bridget","old_macdonald","ride_a_cock_horse_to_course","ring_a_ring_of_roses","round_and_round_the_garden","row_row_your_boat","this_old_man","three_blind_mice","tom_the_pipers_son","wheels_on_the_bus","where_has_my_dog_gone"};
	public AudioSource source;
	private bool isStop=false;
	// Use this for initialization
	void Start () {
		int index = Random.Range (0, clips2.Length - 1);
//		source.PlayOneShot(clips[index]);
		string name = "sounds/christmas/" + clips2 [index];
		AudioClip aCubeOnSlot = Resources.Load(name, typeof(AudioClip)) as AudioClip;
		source.PlayOneShot (aCubeOnSlot);
		text.text = strings[index];
//		image.name = images [index];
		Sprite newSprite =  Resources.Load <Sprite>(images2[index]);
		Debug.Log ("load "+images2[index]);
		if (newSprite){
			image.sprite = newSprite;
		} else {
			Debug.LogError("Sprite not found", this);
		}
		UM_AdManager.instance.CreateAdBanner(TextAnchor.UpperCenter);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			source.Stop ();
			isStop=true;
		}
		if (isStop == true) {
			if(Application.CanStreamedLevelBeLoaded(1)){
				isStop=false;
//				Application.LoadLevelAdditive(1);
				Application.LoadLevel(1);
			}
		}
	}
	void Awake () {
		Debug.Log ("Awake UIPhoneManageDetail");
		UM_AdManager.instance.Init();
		
	}
	public void btnEndClicked()
	{
		source.Stop ();
		Handheld.Vibrate();
		isStop = true;
//		Application.LoadLevel("Phone");
	}
	public void btnDetail1Clicked()
	{
		source.PlayOneShot (cow);
		Handheld.Vibrate();
	}
	public void btnDetail2Clicked()
	{
		source.PlayOneShot (dog);
		Handheld.Vibrate();
	}
	public void btnDetail3Clicked()
	{
		source.PlayOneShot (duck);
		Handheld.Vibrate();
	}
	public void btnDetail4Clicked()
	{
		source.PlayOneShot (coat);
		Handheld.Vibrate();
	}
	public void btnDetail5Clicked()
	{
		source.PlayOneShot (horse);
		Handheld.Vibrate();
	}
	public void btnDetail6Clicked()
	{
		source.PlayOneShot (chicken);
		Handheld.Vibrate();
	}
	public void btnDetail7Clicked()
	{
		source.PlayOneShot (sheep);
		Handheld.Vibrate();
	}
	public void btnDetail8Clicked()
	{
		source.PlayOneShot (frog);
		Handheld.Vibrate();
	}
	public void btnDetail9Clicked()
	{
		source.PlayOneShot (turkey);
		Handheld.Vibrate();
	}
}
