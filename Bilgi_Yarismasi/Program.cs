using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Bilgi_Yarismasi
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Değişkenler
            string girilen_cevap, isim, soy_isim;
            int yanlis = 0, dogru = 0, para = 0;
            #endregion   
            #region Nesne oluşturma
            Console.ForegroundColor = ConsoleColor.Yellow;
            Bilgi tanitim = new Bilgi();
            Console.Title = "Kim Bilir?";
            tanitim.Bilgi_Goster();
            Console.ReadKey();
            Console.Clear();
            #endregion
            #region İlkEkran   
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\tBilgi Yarışmasına Hoş Geldiniz...");
            Console.Write("\n\tİsminiz : ");
            isim = Console.ReadLine();
            Console.Write("\n\tSoyadınız : ");
            soy_isim = Console.ReadLine();
            Console.Write("\n\tHadi Başlayalım...");
            #endregion

            var sorular = new List<Sorular>()
            {
                new Sorular("Hangi Ülkenin İki Tane Başkenti Vardır?","Güney Afrika","Senegal","El Salvador","Venezuela","A"),
                new Sorular("Mustafa Kemal Atatürk’ün Nüfusa Kayıtlı Olduğu İl Hangisidir?","Bursa ","Ankara","İstanbul","Gaziantep","D"),
                new Sorular("\"Sinekli Bakkal\" Romanının Yazarı Aşağıdakilerden Hangisidir?","Reşat Nuri Güntekin","Ziya Gökalp","Halide Edip Adıvar","Ömer Seyfettin","C"),
                new Sorular("\"Jack Nicholson mı,Heath Ledger mı,Joaguin Phoenix mi\" diyen biri muhtemelen hangi sorunun cevabını arıyordur?","En iyi Darth Vader kim?","En iyi Joker kim?"
,"En iyi Terminatör kim?","En iyi Freddy Krueger kim?","B"),
                new Sorular("Cevabı \"sam yeli\" olan bir bulmaca sorusunda sorulan hangisi olur?","Çölden esen sıcak rüzgar"
,"Denizden esen soğuk rüzgar","Nehirden esen sıcak rüzgar","Dağdan esen soğuk rüzgar","A"),
                new Sorular("Hangisi \"Street Fighter\" adlı ünlü video oyunu serisindeki karakterlerden biri değildir?","Lara Croft","Sonya Blade","Tanya","Chun-Li","D"),
                new Sorular("Hangi edebiyatçı TBMM'de milletvekilliği yapmamıştır?","Yahya Kemal Beyatlı","Halide Edip Adıvar","Sait Faik Abasıyanık","Mehmet Akif Ersoy","C"),
                new Sorular("Star-Lord,Gamora,Drax ve Groot hangi film serisinde yer alan karakterlerdir?","Transformers","Galaksinin Koruyucuları","Fantastik Dörtlü","Cehennem Melekleri","B"),
                new Sorular("Tanımı\"mora çalan kırmızı\" olan renk hangisidir?","Ekru","Füme","Bej","Galibarda","D"),
                new Sorular("Hangi çizgi film kahramanı\"Odie\" adlı köpekle aynı evi paylaşır?","Tweety","Sünger Bob","Garfield","Bugs Bunny","C"),
                new Sorular("Scoville ölçeği hangisini ölçer?","Deniz tuzluluğunu","Çikolata tatlılığını","Limon ekşiliğini","Biber acılığını","D"),
                new Sorular("Taumatawhakatangihangakoauauotamateaturipukakapikimaungahoronukupokaiwhenuakitanatahu Tepesi nerededir?","Hawaii","Yeni Zelanda","Galler","Hindistan","B"),
                new Sorular("Yüzüklerin Efendisi: Kralın Dönüşü filmi kaç dalda Oscar kazanmıştır?","8","9","11","13","C"),
                new Sorular("Yolculuğunu neyle yaptığını sorduğunuz kişi hangi cevabı verirse gemi yolculuğu yaptığını söylemiş olur?","Sefine","Şimendifer","Velespit","Tayyare","A"),
                new Sorular("\"Tanrı Parçacığı\" olarak bilinen teoremiyle,2013 Nobel Fizik Ödülü'nü kazanan fizikçi kimdir?","Stephen Hawking","Carl Sagan","Arthur C.Clarke","Peter Higgs","D"),
                new Sorular("Bilinen 118 element arasında hangi isimde bir element yoktur?","Aynştaynyum","Newtonyum","Mendelevyum","Nobelyum","B"),
                new Sorular("\"Şimdi nereye çufçufluyoruz?\" sözü 90'ların hangi ünlü televizyon programı karakterine aittir?","Pepee","Pokemon","Hugo","Furby","C"),
                new Sorular("\"Yenidünya\" meyvesi başka hangi adla anılır?","Malta Eriği","Karadut","Muşmula","Hurma","A"),
                new Sorular("1969'da polisin sonlandırmasıyla 42 dk süren son konserlerini kimseye haber vermeden ve izin almadan bir çatıda veren müzik grubu hangisidir?","The Rolling Stones","The Beatles",
                "Pink Floyd","Jethro Tull","B"),
                new Sorular("George Orwell’in “Avrupada’ki Son Adam” adıyla yazdığı,basılırken pazarlamaya yönelik nedenlerle günümüzdeki adıyla değiştirilen romanı hangisidir?","Hayvan Çiftliği","Paris ve Londra'da Beş Parasız",
                "1984","Aspidistra","C"),
                new Sorular("“Çalışmak insanı özgürleştirir” sözü Almanya’daki hangi yapının girişinde yer almasıyla ün kazanmıştır?","Berlin Parlamento Binası","İşçi Partisi Binası","Münih Olimpiyat Stadı","Nazi Toplama Kampı","D"),
                new Sorular("Morpheus,Neo’nun kırmızı ve mavi hap arasında seçim yapmasını istiyorsa hangi filmi izliyorsunuz demektir?","V for Vendetta","Matrix","Django","Inception","B"),
                new Sorular("Yunan mitolojisinde berberinin bir kuyuya, kulaklarının eşek kulakları olduğu sırrını söylediği Midas hangi ülkenin kralıdır?","Makedonya","İyonya","Hitit","Frigya","D"),
                new Sorular("\"Hoşçakal\",\"Son Defa\",\"Belki Bir Gün Özlersin\" adlı şarkıları olan sanatçı kimdir?","Emre Aydın","Şebnem Ferah","İsmail YK","Kazım Koyuncu","A"),
                new Sorular("Hiçbir Avrupa ülkesi sömürgeleştiremediği için bayrağının renkleri birçok Afrika ülkesinin bayrağına ilham vermiş olan ülke hangisidir?","Liberya","Etiyopya","Kenya","Angola","B")

            };

            List<int> sayilar = new List<int>();
            List<int> sayilar2 = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                Console.Clear();

                for (int c = 0; c < 25; c++)
                {
                    sayilar.Add(i);
                }


                for (int d = 0; d < 12; d++)
                {
                    bool donguMu = false;
                    Random a = new Random();
                    int b = a.Next(25);
                    while (!donguMu)
                    {
                        if (sayilar2.Contains(b))
                        {
                            b = a.Next(25);
                        }

                        else
                        {
                            sayilar2.Add(b);
                            donguMu = !donguMu;
                            break;
                        }
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(sorular[b]);

                    Console.Write("\n Cevabınız: ");
                    girilen_cevap = Console.ReadLine().ToUpper();
                    Console.WriteLine();
                    while (girilen_cevap != "A" && girilen_cevap != "B" && girilen_cevap != "C" && girilen_cevap != "D")
                    {
                        Console.WriteLine("Hatalı Giriş...");
                        Console.Write("\n Cevabınızı Yeniden Giriniz: ");
                        girilen_cevap = Console.ReadLine().ToUpper();
                        Console.WriteLine();
                    }
                    if (girilen_cevap == sorular[b].getCevap())
                    {
                        dogru++; para = para + 1000; Console.WriteLine("\n   + Tebrikler Doğru Cevap :))");
                    }
                    else
                    {
                        yanlis++; Console.WriteLine("\n   - Maalesef Yanlış Cevap :((");
                    }
                    Console.Write("\n → Devam Etmek İçin Bir Tuşa Basınız..");
                    Console.WriteLine();
                    Console.ReadKey();
                }

                #region SonEkran
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n  Tebrikler..   " +
                    $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(isim)} " +
                    $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(soy_isim)}  " +
                    $"Kazandığınız Para " +
                    $"{para}TL " +
                    $"\n\n  İstatistik: {dogru} Doğru  {yanlis} Yanlış");
                Console.ReadLine();
                Environment.Exit(0);
                #endregion
            }
        }
    }
    class Bilgi
    {
        public void Bilgi_Goster()
        {
            Console.WriteLine($"\n  Mehmet Toprak 202113709027  " +
                $"\n\n - Projem \"Kim Bilir?\" adlı bir bilgi yarışmasıdır.\n - Soru havuzundan rastgele 12 soru gelmektedir." +
                $"\n - Doğru cevapladığınız her soru başına 1000 TL kazandıran bir bilgi yarışmasıdır. " +
                $"\n - Yarışmaya başlamak için bir tuşa basınız.. ");

        }
    }
    class Sorular
    {

        #region Kapsülleme
        private String soru;
        private String secenekA;
        private String secenekB;
        private String secenekC;
        private String secenekD;
        private String cevap;
        #endregion


        public Sorular(string soru, string secenekA, string secenekB, string secenekC, string secenekD, string cevap)
        {
            this.soru = soru;
            this.secenekA = secenekA;
            this.secenekB = secenekB;
            this.secenekC = secenekC;
            this.secenekD = secenekD;
            this.cevap = cevap;
        }

        public void setSoru(String soru)
        {
            this.soru = soru;
        }

        public String getSoru()
        {
            return soru;
        }
        public void setSıkA(String secenekA)
        {
            this.secenekA = secenekA;
        }

        public String getSecenekA()
        {
            return secenekA;
        }

        public void setSıkB(String secenekB)
        {
            this.secenekB = secenekB;
        }

        public String getSecenekB()
        {
            return secenekB;
        }

        public void setSecenekC(String secenekC)
        {
            this.secenekC = secenekC;
        }

        public String getSecenekC()
        {
            return secenekC;
        }

        public void setSecenekD(String secenekD)
        {
            this.secenekD = secenekD;
        }

        public String getSecenekD()
        {
            return secenekD;
        }

        public void setCevap(String cevap)
        {
            this.cevap = cevap;
        }

        public String getCevap()
        {
            return cevap;
        }
        public override string ToString()
        {
            return $"\n  {soru}\n\n A-{secenekA}\n B-{secenekB}\n C-{secenekC}\n D-{secenekD}";
        }
    }
}
