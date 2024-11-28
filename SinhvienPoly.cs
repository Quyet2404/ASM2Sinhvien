using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhvienTests
{
    public class SinhvienPoly
    {
        private List<Sinhvien> danhSachSinhVien = new List<Sinhvien>();

        // Thêm sinh viên
        public void ThemSinhVien(Sinhvien sv)
        {
            danhSachSinhVien.Add(sv);
        }

        // Tìm sinh viên theo tên
        public List<Sinhvien> TimKiemTheoTen(string ten)
        {
            return danhSachSinhVien.Where(sv => sv.Hoten.Contains(ten)).ToList();
        }

        // Tìm sinh viên theo mã lớp
        public List<Sinhvien> TimKiemTheoMalop(string malop)
        {
            return danhSachSinhVien.Where(sv => sv.Malop.Equals(malop)).ToList();
        }

        // Tìm sinh viên theo mã sinh viên
        public Sinhvien TimKiemTheoMasv(string masv)
        {
            return danhSachSinhVien.FirstOrDefault(sv => sv.Masv.Equals(masv));
        }
    }
}
