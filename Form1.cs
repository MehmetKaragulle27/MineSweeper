// Oyun alanı ve butonları oluşturmak için kullanılan dizi ve değişkenler
private Tahta tahta;
private Button[,] butonlar;
private int satir = 5;
private int sutun = 5;
private int mayinSayisi = 5;

public Form1()
{
    InitializeComponent();
    // Zorluk butonlarının tıklama olaylarını bağla
    btnKolay.Click += btnKolay_Click;
    btnOrta.Click += btnOrta_Click;
    btnZor.Click += btnZor_Click;
}

/// <summary>
/// Seçilen zorluk seviyesine göre oyun alanını ve butonları oluşturur.
/// </summary>
private void OyunBaslat(IOyunSeviyesi seviye)
{
    tahta = new Tahta(seviye.Satir, seviye.Sutun, seviye.MayinSayisi);
    butonlar = new Button[seviye.Satir, seviye.Sutun];
    this.Controls.Clear();

    // 3 zorluk butonunu tekrar ekle
    this.Controls.Add(btnKolay);
    this.Controls.Add(btnOrta);
    this.Controls.Add(btnZor);

    // Oyun alanındaki butonları oluştur
    for (int i = 0; i < seviye.Satir; i++)
    {
        for (int j = 0; j < seviye.Sutun; j++)
        {
            Button btn = new Button();
            btn.Width = 40;
            btn.Height = 40;
            btn.Left = j * 42;
            btn.Top = i * 42 + 50; // Butonlar yukarıda kalsın diye
            btn.Tag = new Point(i, j);
            btn.Click += Btn_Click;
            btn.MouseUp += Btn_MouseUp;
            this.Controls.Add(btn);
            butonlar[i, j] = btn;
        }
    }
}

/// <summary>
/// Sağ tık ile hücreye bayrak koyar veya kaldırır.
/// </summary>
private void Btn_MouseUp(object sender, MouseEventArgs e)
{
    if (e.Button == MouseButtons.Right)
    {
        Button btn = sender as Button;
        Point p = (Point)btn.Tag;
        int x = p.X;
        int y = p.Y;

        var hucre = tahta.Hucreler[x, y];

        if (hucre.AcildiMi)
            return; // Açılmış hücreye bayrak koyulmaz

        hucre.Isaretli = !hucre.Isaretli;

        if (hucre.Isaretli)
        {
            btn.Text = "🚩"; // veya "B"
            btn.ForeColor = Color.Red;
        }
        else
        {
            btn.Text = "";
            btn.ForeColor = Color.Black;
        }
    }
}

/// <summary>
/// Sol tık ile hücre açılır. Mayına basılırsa oyun biter.
/// </summary>
private void Btn_Click(object sender, EventArgs e)
{
    Button btn = sender as Button;
    Point p = (Point)btn.Tag;
    int x = p.X;
    int y = p.Y;

    var hucre = tahta.Hucreler[x, y];

    if (hucre.AcildiMi || hucre.Isaretli)
        return; // Bayraklı veya açılmış hücre açılmaz

    hucre.AcildiMi = true;

    if (hucre.MayinVarMi)
    {
        btn.Text = "*";
        btn.BackColor = Color.Red;
        OyunBitti(false);
    }
    else
    {
        btn.Text = hucre.EtrafindakiMayinSayisi.ToString();
        btn.Enabled = false;
        if (KazandiMi())
            OyunBitti(true);
    }
}

/// <summary>
/// Oyun bittiğinde tüm butonları pasif yapar ve mesaj gösterir.
/// </summary>
private void OyunBitti(bool kazandi)
{
    foreach (var btn in butonlar)
        btn.Enabled = false;

    string mesaj = kazandi ? "Tebrikler, kazandınız!" : "Mayına bastınız! Oyun bitti.";
    MessageBox.Show(mesaj);
}

/// <summary>
/// Tüm güvenli hücreler açıldıysa true döner (oyun kazanıldı).
/// </summary>
private bool KazandiMi()
{
    for (int i = 0; i < satir; i++)
        for (int j = 0; j < sutun; j++)
            if (!tahta.Hucreler[i, j].MayinVarMi && !tahta.Hucreler[i, j].AcildiMi)
                return false;
    return true;
}

// Zorluk seviyelerini polimorfizm ile tanımlayan arayüz ve sınıflar
public interface IOyunSeviyesi
{
    int Satir { get; }
    int Sutun { get; }
    int MayinSayisi { get; }
}

public class KolaySeviye : IOyunSeviyesi
{
    public int Satir => 5;
    public int Sutun => 5;
    public int MayinSayisi => 5;
}

public class OrtaSeviye : IOyunSeviyesi
{
    public int Satir => 8;
    public int Sutun => 8;
    public int MayinSayisi => 15;
}

public class ZorSeviye : IOyunSeviyesi
{
    public int Satir => 10;
    public int Sutun => 10;
    public int MayinSayisi => 25;
} 