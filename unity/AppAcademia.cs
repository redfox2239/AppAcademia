using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class AppAcademiaMonoBehaviour : MonoBehaviour
{
    public GameObject _部品_ぶひん
    {
        get
        {
            return gameObject;
        }
    }
    public virtual void スタートしたとき() { }
    public virtual void アップデートしたとき() { }
    public virtual void 触れ始めたとき_ふれはじめたとき(Collider2D collision) { }
    public virtual void 触れているとき_ふれているとき(Collider2D collision) { }
    public virtual void 触れ終わりのとき_ふれおわりのとき(Collider2D collision) { }
    public virtual void 衝突し始めたとき_しょうとつしはじめたとき(Collision2D collision) { }
    public virtual void 衝突しているとき_しょうとつしているとき(Collision2D collision) { }
    public virtual void 衝突終わりのとき_しょうとつおわりのとき(Collision2D collision) { }
    private void Start()
    {
        スタートしたとき();
    }
    private void Update()
    {
        アップデートしたとき();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        触れ始めたとき_ふれはじめたとき(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        触れているとき_ふれているとき(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        触れ終わりのとき_ふれおわりのとき(collision);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        衝突し始めたとき_しょうとつしはじめたとき(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        衝突しているとき_しょうとつしているとき(collision);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        衝突終わりのとき_しょうとつおわりのとき(collision);
    }
}
static class GameObjectExtensions
{
    public static void _隠す_かくす(this GameObject obj)
    {
        SingletonClass.GetSingleton().add(obj.name, obj);
        obj.SetActive(false);
    }
    public static void _表示する_ひょうじする(this GameObject obj)
    {
        obj.SetActive(true);
    }
    public static string _文字_もじ(this GameObject obj)
    {
        return obj.GetComponent<Text>().text;
    }
    public static void _文字変更_もじへんこう(this GameObject obj, string str)
    {
        obj.GetComponent<Text>().text = str;
    }
    public static float _文字を数字に変換する_もじをしょうすうにへんかんする(this GameObject obj)
    {
        var str = obj.GetComponent<Text>().text;
        return int.Parse(str);
    }
    public static float _文字を少数に変換する_もじをしょうすうにへんかんする(this GameObject obj)
    {
        var str = obj.GetComponent<Text>().text;
        return float.Parse(str);
    }
    public static double _文字を長い少数に変換する_もじをながいしょうすうにへんかんする(this GameObject obj)
    {
        var str = obj.GetComponent<Text>().text;
        return double.Parse(str);
    }
    public static void _プラスする(this GameObject obj, double value, string format = "D")
    {
        var str = value.ToString();
        obj._プラスする(str, format);
    }
    public static void _プラスする(this GameObject obj, string str, string format = "D")
    {
        var answer = obj._文字を長い少数に変換する_もじをながいしょうすうにへんかんする() + double.Parse(str);
        var val = "";
        if (format == "D")
        {
            val = ((int)answer).ToString();
        }
        else
        {
            val = answer.ToString(format);
        }
        obj._文字変更_もじへんこう(val);
    }
    public static void _マイナスする(this GameObject obj, double value, string format = "D")
    {
        var str = value.ToString();
        obj._マイナスする(str, format);
    }
    public static void _マイナスする(this GameObject obj, string str, string format = "D")
    {
        var answer = obj._文字を長い少数に変換する_もじをながいしょうすうにへんかんする() - double.Parse(str);
        var val = "";
        if (format == "D")
        {
            val = ((int)answer).ToString();
        }
        else
        {
            val = answer.ToString(format);
        }
        obj._文字変更_もじへんこう(val);
    }
    public static void _画像変更_がぞうへんこう(this GameObject obj, string str)
    {
        var sp = Resources.Load<Sprite>("str");
        obj.GetComponent<Image>().sprite = sp;
    }
    public static void _向きを変える(this GameObject obj, string str = "")
    {
        var initScale = obj.transform.localScale;
        if (str == "")
        {
            initScale.x = (-1) * initScale.x;
        }
        else if (str == "右")
        {
            initScale.x = 1;
        }
        else if (str == "左")
        {
            initScale.x = -1;
        }
        else if (str == "上")
        {
            initScale.y = 1;
        }
        else if (str == "下")
        {
            initScale.y = -1;
        }
        obj.transform.transform.localScale = initScale;
    }
    public static void _移動する_いどうする(this GameObject obj, double x, double y, double z)
    {
        obj.transform.Translate((float)x, (float)y, (float)z);
    }
    public static void _位置を変更する_いちをへんこうする(this GameObject obj, double x, double y, double z)
    {
        var pos = obj.transform.position;
        pos.x = (float)x;
        pos.y = (float)y;
        pos.z = (float)z;
        obj.transform.position = pos;
    }
    public static void _回転する_かいてんする(this GameObject obj, double x, double y, double z)
    {
        obj.transform.Rotate((float)x, (float)y, (float)z);
    }
    public static void _力を加える_ちからをくわえる(this GameObject obj, double x, double y)
    {
        Rigidbody2D r2b = obj.GetComponent<Rigidbody2D>();
        if (!r2b)
        {
            obj.AddComponent<Rigidbody2D>();
            r2b = obj.GetComponent<Rigidbody2D>();
        }
        Vector2 force = new Vector2((float)x, (float)y);
        r2b.AddForce(force);
    }
    public static Vector3 _座標_ざひょう(this GameObject obj)
    {
        return obj.transform.position;
    }
    public static String _数字から文字に変更_すうじからもじにへんこう(this double d)
    {
        return d.ToString("F2");
    }
    public static String _数字から文字に変更_すうじからもじにへんこう(this float d)
    {
        return d.ToString("F2");
    }
    public static void _音を鳴らす_おとをならす(this GameObject obj, string str)
    {
        var audio = obj.GetComponents<AudioSource>();
        for (var i = 0; i < audio.Length; i++)
        {
            var name = audio[i].clip.name;
            if (str == name)
            {
                audio[i].Play();
            }
        }
    }
    public static bool _画面の端についたら(this GameObject obj)
    {
        if (obj._座標_ざひょう().x <= (-1) * _画面_がめん.横幅_よこはば()) return true;
        if (obj._座標_ざひょう().x >= _画面_がめん.横幅_よこはば()) return true;
        if (obj._座標_ざひょう().y >= _画面_がめん.高さ_たかさ()) return true;
        if (obj._座標_ざひょう().y <= (-1) * _画面_がめん.高さ_たかさ()) return true;
        return false;
    }
    public static void _廃棄する(this GameObject obj)
    {
        UnityEngine.Object.Destroy(obj);
    }
    public static bool _と衝突したか_としょうとつしたか(this GameObject obj, GameObject targetObj)
    {
        var dPos = obj.transform.position - targetObj.transform.position;
        var distance = dPos.magnitude;
        var objHeight = obj.GetComponent<SpriteRenderer>().size.y / 2;
        var targetObjHeight = targetObj.GetComponent<SpriteRenderer>().size.y / 2;
        if (distance < objHeight + targetObjHeight)
        {
            return true;
        }
        return false;
    }
    public static double _高さ_たかさ(this GameObject obj)
    {
        return (double)obj.GetComponent<SpriteRenderer>().size.y;
    }
    public static double _横幅_よこはば(this GameObject obj)
    {
        return (double)obj.GetComponent<SpriteRenderer>().size.x;
    }
    public static double _左右の速さ(this GameObject obj)
    {
        var rb = obj.GetComponent<Rigidbody2D>();
        return Math.Abs(rb.velocity.x);
    }
    public static double _上下の速さ(this GameObject obj)
    {
        var rb = obj.GetComponent<Rigidbody2D>();
        return Math.Abs(rb.velocity.y);
    }
    public static string _上下の向き(this GameObject obj)
    {
        var rb = obj.GetComponent<Rigidbody2D>();
        if (rb.velocity.y > 0)
        {
            return "上";
        }
        else if (rb.velocity.y == 0)
        {
            return "止";
        }
        else
        {
            return "下";
        }
    }
    public static string _左右の向き(this GameObject obj)
    {
        var rb = obj.GetComponent<Rigidbody2D>();
        if (rb.velocity.x > 0)
        {
            return "右";
        }
        else if (rb.velocity.y == 0)
        {
            return "止";
        }
        else
        {
            return "左";
        }
    }
    public static void _アニメーションの変更_アニメーションのへんこう(this GameObject obj, string str)
    {
        var animator = obj.GetComponent<Animator>();
        animator.SetTrigger(str);
    }
    public static void _アニメーションの速度_アニメーションのそくど(this GameObject obj, double speed)
    {
        var animator = obj.GetComponent<Animator>();
        animator.speed = (float)speed;
    }
    public static bool _手で触ったとき_てでさわったとき(this GameObject obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

        if (hit2d)
        {
            if (obj == hit2d.transform.gameObject)
            {
                return true;
            }
        }
        return false;
    }
    public static bool _クリックしたとき_くりっくしたとき(this GameObject obj)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                if (obj == hit2d.transform.gameObject)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
class _加速度センサー_かそくどセンサー
{
    public static double x()
    {
        return Input.acceleration.x;
    }
    public static double y()
    {
        return Input.acceleration.y;
    }
    public static double z()
    {
        return Input.acceleration.z;
    }
}
class _全部品_ぜんぶひん
{
    public static GameObject 探す(String str)
    {
        if (GameObject.Find(str) == null)
        {
            return SingletonClass.GetSingleton().members[str];
        }
        return GameObject.Find(str);
    }
}
class _乱数_らんすう
{
    public static int 作る_つくる(int to, int from)
    {
        var random = new System.Random();
        return random.Next(to, from);
    }
}
class _キーボード
{
    public static bool スペースをおしたら()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    public static bool 右をおしたら_みぎをおしたら()
    {
        return Input.GetKeyDown(KeyCode.RightArrow);
    }
    public static bool 左をおしたら_ひだりをおしたら()
    {
        return Input.GetKeyDown(KeyCode.LeftArrow);
    }
    public static bool 上をおしたら_みぎをおしたら()
    {
        return Input.GetKeyDown(KeyCode.UpArrow);
    }
    public static bool 下をおしたら_したをおしたら()
    {
        return Input.GetKeyDown(KeyCode.DownArrow);
    }
    public static bool スペースをおしっぱなしにしたら()
    {
        return Input.GetKey(KeyCode.Space);
    }
    public static bool 右をおしっぱなしにしたら_みぎをおしっぱなしにしたら()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }
    public static bool 左をおしっぱなしにしたら_ひだりをおしっぱなしにしたら()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }
    public static bool 上をおしっぱなしにしたら_みぎをおしっぱなしにしたら()
    {
        return Input.GetKey(KeyCode.UpArrow);
    }
    public static bool 下をおしっぱなしにしたら_したをおしっぱなしにしたら()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }
}
class _タッチ
{
    public static double x座標()
    {
        return (double)Input.mousePosition.x;
    }
    public static double y座標()
    {
        return (double)Input.mousePosition.y;
    }
}
class _画面_がめん
{
    public static bool 手で触り始めたら_さわりはじめたら()
    {
        if (EventSystem.current != null)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return false;
        }
        return Input.GetMouseButtonDown(0);
    }
    public static bool 手を離したら_てをはなしたら()
    {
        if (EventSystem.current != null)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return false;
        }
        return Input.GetMouseButtonUp(0);
    }
    public static float 高さ_たかさ()
    {
        return Camera.main.orthographicSize;
    }
    public static float 横幅_よこはば()
    {
        var h = Camera.main.orthographicSize;
        var rate = (float)Screen.width / (float)Screen.height;
        return h * rate;
    }
    public static void シーン切り替え(string str)
    {
        SceneManager.LoadScene(str);
    }
}
class SingletonClass
{
    private static SingletonClass _share = new SingletonClass();
    public Dictionary<string, GameObject> members;
    private SingletonClass()
    {
        members = new Dictionary<string, GameObject>();
    }
    public static SingletonClass GetSingleton()
    {
        return _share;
    }
    public void add(string key, GameObject value)
    {
        if (!SingletonClass.GetSingleton().members.ContainsKey(key))
        {
            SingletonClass.GetSingleton().members.Add(key, value);
        }
    }
}
