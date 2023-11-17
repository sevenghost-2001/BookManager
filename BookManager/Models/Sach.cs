using System;
using System.Collections.Generic;

namespace BookManager.Models
{
    public partial class Sach
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; } = null!;
        public string TacGia { get; set; } = null!;
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public string? Hinh { get; set; }
        public string? TheLoai { get; set; }

        public virtual TheLoai? TheLoaiNavigation { get; set; }
    }
}
