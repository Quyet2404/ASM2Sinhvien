using NUnitAssert = NUnit.Framework.Assert;
using MSTestAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using NUnit.Framework;
using System.Collections.Generic;

namespace SinhvienTests
{
    [TestFixture]
    public class SinhvienPolyTests
    {
        private SinhvienPoly sinhvienPoly;

        [SetUp]
        public void Setup()
        {
            sinhvienPoly = new SinhvienPoly();
        }

        // 10 Testcase kiểm tra thêm sinh viên
        [Test]
        public void ThemSinhVien_ValidSinhVien_Success()
        {
            var sv = new Sinhvien("1", "Nguyen Van A", "CSE01", "Công nghệ thông tin", "SV001");
            sinhvienPoly.ThemSinhVien(sv);

            var result = sinhvienPoly.TimKiemTheoMasv("SV001");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(sv, result);
        }

        [Test]
        public void ThemSinhVien_TenLopKhongKyTuDacBiet_Success()
        {
            var sv = new Sinhvien("2", "Le Van B", "CSE02", "KyThuatPhanMem", "SV002");
            sinhvienPoly.ThemSinhVien(sv);

            var result = sinhvienPoly.TimKiemTheoMasv("SV002");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(sv, result);
        }

        [Test]
        public void ThemSinhVien_TenLopCoKyTuDacBiet_Fail()
        {
            var sv = new Sinhvien("3", "Tran Van C", "CSE03", "Công-nghệ*", "SV003");

            Assert.Throws<System.ArgumentException>(() =>
            {
                sinhvienPoly.ThemSinhVien(sv);
            });
        }

        [Test]
        public void ThemSinhVien_TenSinhVienRong_Fail()
        {
            var sv = new Sinhvien("4", "", "CSE04", "KhoaHocMayTinh", "SV004");

            Assert.Throws<System.ArgumentException>(() =>
            {
                sinhvienPoly.ThemSinhVien(sv);
            });
        }

        [Test]
        public void ThemSinhVien_MaSinhVienTrung_Fail()
        {
            var sv1 = new Sinhvien("5", "Nguyen D", "CSE05", "HeThongThongTin", "SV005");
            var sv2 = new Sinhvien("6", "Pham E", "CSE06", "KhoaHocDuLieu", "SV005");

            sinhvienPoly.ThemSinhVien(sv1);
            Assert.Throws<System.InvalidOperationException>(() =>
            {
                sinhvienPoly.ThemSinhVien(sv2);
            });
        }

        // Thêm 5 test khác cho trường hợp biên:
        // 1. Mã lớp rỗng, null
        // 2. Mã sinh viên hoặc tên lớp có độ dài lớn hơn 50 ký tự
        // 3. Thêm sinh viên với tất cả các thông tin hợp lệ.

        // 5 Testcase tìm kiếm theo masv (phân vùng tương đương)
        [Test]
        public void TimKiemTheoMasv_TimThay_Success()
        {
            var sv = new Sinhvien("7", "Nguyen F", "CSE07", "HeThongThongTin", "SV007");
            sinhvienPoly.ThemSinhVien(sv);

            var result = sinhvienPoly.TimKiemTheoMasv("SV007");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(sv, result);
        }

        [Test]
        public void TimKiemTheoMasv_KhongTimThay_Fail()
        {
            var result = sinhvienPoly.TimKiemTheoMasv("SV999");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TimKiemTheoMasv_MasvNull_Fail()
        {
            var result = sinhvienPoly.TimKiemTheoMasv(null);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TimKiemTheoMasv_MasvRong_Fail()
        {
            var result = sinhvienPoly.TimKiemTheoMasv("");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TimKiemTheoMasv_MasvSaiDinhDang_Fail()
        {
            var result = sinhvienPoly.TimKiemTheoMasv("SV-001");
            Assert.That(result, Is.Null);
        }
    }
}
