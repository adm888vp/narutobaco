using System.Globalization;
using System.Text;

public class Program
{
    static int soluong = 0;
    static qlyxemay[] ds;
    static void menu()
    {
        Console.WriteLine("________Quản lý xe máy_______");
        Console.WriteLine("1._____ Nhập thông tin");
        Console.WriteLine("2.______ Sửa thông tin");
        Console.WriteLine("3.______ Xóa thông tin");
        Console.WriteLine("4.__ Hiển thị thông tin");
        Console.WriteLine("5.__ Tìm kiếm thông tin");
        Console.WriteLine("6.__ Lưu thông tin");
        Console.WriteLine("7.__ Thống kê xe máy");
        Console.WriteLine("8.__ Doanh thu xe máy");
        Console.WriteLine("0.__ Thoát chương trình");
    }

    static void chaychuongtrinh()
    {
        int chucnang = -1;
        while (chucnang != 0)
        {
            Console.Write("Mời bạn chọn chức năng: ");
            chucnang = int.Parse(Console.ReadLine());
            switch (chucnang)
            {
                case 1:
                    nhapthongtin();
                    break;
                case 2:
                    suathongtin();
                    break;
                case 3:
                    xoathongtin();
                    break;
                case 4:
                    hienthithongtin();
                    break;
                case 5:
                    timkiemthongtin();
                    break;
                case 6:
                    LuuThongTinXe();
                    break;
                case 7:
                    thongkexemay();
                    break;
                case 8:
                    tinhdoanhthu();
                    break;
                case 0:
                    Console.WriteLine("Chương trình đã kết thúc!");
                    break;
                default:
                    Console.WriteLine("Chức năng không hợp lệ!");
                    break;
            }
            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
            Console.Clear();
            menu();
        }
    }
    static void nhapthongtin()
    {
        Console.WriteLine("Mời Nhập Số Lượng Bạn Muốn");
        soluong = int.Parse(Console.ReadLine());
        ds = (qlyxemay[])Array.CreateInstance(typeof(qlyxemay), soluong);
        int dem = 1;
        for (int i = 0; i < soluong; i++)
        {
            Console.WriteLine("Mời Nhập Tên Xe" + dem++);
            ds[i].tenhang = Console.ReadLine();
            Console.WriteLine("Mời Nhập Mã Xe Máy");
            ds[i].mahang = Console.ReadLine();
            Console.WriteLine("Mời Nhập số lượng ");
            ds[i].soluong = int.Parse(Console.ReadLine());
            Console.WriteLine("Mời Nhập Giá Sản Phẩm");
            ds[i].gia = int.Parse(Console.ReadLine());
            Console.WriteLine("mời nhập ngày");
            do
            {
                ds[i].ngay = int.Parse(Console.ReadLine());
            } while (ds[i].ngay > 31);
            Console.WriteLine("mời nhập tháng");
            do
            {
                ds[i].thang = int.Parse(Console.ReadLine());
            } while (ds[i].thang > 13);
            Console.WriteLine("mời nhập năm");
            ds[i].nam = int.Parse(Console.ReadLine());
            Console.Clear();
        }
    }

    static void suathongtin()
    {
        Console.WriteLine("Mời Nhập Mã Xe Máy Cần Sửa Thông Tin");
        string nhapma = Console.ReadLine();
        for (int i = 0; i < soluong; i++)
        {
            if (ds[i].mahang.Equals(nhapma))
            {
                Console.WriteLine("Mời Nhập Tên Xe");
                ds[i].tenhang = Console.ReadLine();
                Console.WriteLine("Mời Nhập số lượng ");
                ds[i].soluong = int.Parse(Console.ReadLine());
                Console.WriteLine("Mời Nhập Giá Sản Phẩm");
                ds[i].gia = int.Parse(Console.ReadLine());
                Console.WriteLine("mời nhập ngày");
                do
                {
                    ds[i].ngay = int.Parse(Console.ReadLine());
                } while (ds[i].ngay > 31);
                Console.WriteLine("mời nhập tháng");
                do
                {
                    ds[i].thang = int.Parse(Console.ReadLine());
                } while (ds[i].thang > 13);
                Console.WriteLine("mời nhập năm");
                ds[i].nam = int.Parse(Console.ReadLine());
                Console.Clear();
                break;
            }
        }
    }

    static void xoathongtin()
    {
        Console.WriteLine("Nhập mã hàng cần xóa:");
        string maXoa = Console.ReadLine();
        bool ktra = false;
        for (int j = 0; j < ds.Length; j++)
        {
            if (ds[j].mahang == maXoa)
            {
                for (int k = j + 1; k < ds.Length; k++)
                {
                    ds[k - 1] = ds[k];
                }
                Array.Resize(ref ds, ds.Length - 1);
                soluong--;
                ktra = true;
                Console.WriteLine("Xóa thành công!");
                break;
            }
        }
        if (!ktra)
        {
            Console.WriteLine("Không tìm thấy sản phẩm cần xóa!");
        }
    }

    static void hienthithongtin()
    {
        Console.WriteLine("-----Thông tin xe máy-----");
        Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10}", "Tên xe", "Mã xe", "Số lượng", "Giá", "Ngày cập nhật");
        for (int i = 0; i < soluong; i++)
        {
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10}/{5}/{6}", ds[i].tenhang, ds[i].mahang, ds[i].soluong, ds[i].gia, ds[i].ngay, ds[i].thang, ds[i].nam);
        }
    }
    static void timkiemthongtin()
    {
        Console.WriteLine("Nhập mã hàng cần tìm kiếm:");
        string maTimKiem = Console.ReadLine();
        bool ktra = false;
        for (int i = 0; i < soluong; i++)
        {
            if (ds[i].mahang == maTimKiem)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10}", "Tên xe", "Mã xe", "Số lượng", "Giá", "Ngày cập nhật");
                Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10}/{5}/{6}", ds[i].tenhang, ds[i].mahang, ds[i].soluong, ds[i].gia, ds[i].ngay, ds[i].thang, ds[i].nam);
                ktra = true;
                break;
            }
        }
        if (!ktra)
        {
            Console.WriteLine("Không tìm thấy sản phẩm cần tìm kiếm!");
        }
    }
    static void LuuThongTinXe()
    {
        //mở file để ghi dữ liệu
        StreamWriter writer = new StreamWriter("xemay.txt");
        //ghi từng dòng thông tin của mỗi xe máy vào file
        for (int i = 0; i < soluong; i++)
        {
            writer.WriteLine(ds[i].tenhang);
            writer.WriteLine(ds[i].mahang);
            writer.WriteLine(ds[i].soluong);
            writer.WriteLine(ds[i].gia);
            writer.WriteLine(ds[i].ngay);
            writer.WriteLine(ds[i].thang);
            writer.WriteLine(ds[i].nam);
        }
        //đóng file
        writer.Close();
    }
    static void thongkexemay()
    {
        Console.WriteLine("-----Thống kê xe máy-----");
        int tongso = 0;
        int tonggia = 0;
        int maxgia = int.MinValue;
        int mingia = int.MaxValue;
        string maxhang = "";
        string minhang = "";
        for (int i = 0; i < soluong; i++)
        {
            tongso += ds[i].soluong;
            tonggia += ds[i].gia;
            if (ds[i].gia > maxgia)
            {
                maxgia = ds[i].gia;
                maxhang = ds[i].mahang;
            }
            if (ds[i].gia < mingia)
            {
                mingia = ds[i].gia;
                minhang = ds[i].mahang;
            }
        }
        Console.WriteLine("Tổng số xe máy: {0}", tongso);
        Console.WriteLine("Giá trung bình của xe máy: {0}", (double)tonggia / soluong);
        Console.WriteLine("Xe máy đắt nhất: {0} - {1}", maxhang, maxgia);
        Console.WriteLine("Xe máy rẻ nhất: {0} - {1}", minhang, mingia);
    }
    static void tinhdoanhthu()
    {
        Console.WriteLine("Nhập tháng cần tính doanh thu:");
        int thang = int.Parse(Console.ReadLine());
        int tongdoanhthu = 0;
        for (int i = 0; i < soluong; i++)
        {
            if (ds[i].thang == thang)
            {
                ds[i].doanhthu = ds[i].soluong * ds[i].gia;
                tongdoanhthu += ds[i].doanhthu;
            }
        }
        Console.WriteLine("Tổng doanh thu của tháng {0} là: {1}", thang, tongdoanhthu);
    }


    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string user, matkhau;
        bool kt = false;
        do
        {
            Console.Write("Nhập User : ");
            user = Console.ReadLine();
            Console.Write("Nhập Pass : ");
            matkhau = Console.ReadLine();
            if (user.Equals("admin") && matkhau.Equals("1402"))
                kt = true;
            else Console.WriteLine("hãy nhập lại thông tin admin");
        } while (kt == false);
        menu();
        chaychuongtrinh();
    }
}
struct qlyxemay
{
    public string tenhang;
    public string mahang;
    public int soluong;
    public int gia;
    public int ngay;
    public int thang;
    public int nam;
    public int doanhthu;
}