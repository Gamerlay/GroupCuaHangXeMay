create proc ThemNhanVien
@manv nvarchar(10),@honv nvarchar(30),@tennv nvarchar(10), @luong int = 1, @chucvu nvarchar(20), @diachi nvarchar(50), @sdt nvarchar(11),@email nvarchar(50)
AS
	INSERT INTO NhanVien(MaNV,HoNV, TenNV,Luong,ChucVu,DiaChi,SDT,Email)
	values (@manv,@honv,@tennv,@luong,@chucvu,@diachi,@sdt, @email)
go
----------------------------------------------

create proc ThemKhachHang
@makh nvarchar(10),@hokh nvarchar(30),@tenkh nvarchar(10), @diachi nvarchar(50), @sdt nvarchar(11),@email nvarchar(50)
AS
	INSERT INTO KhachHang(MaKH,HoKH, TenKH,SDT ,DiaChi,Email)
	values (@makh,@hokh,@tenkh,@sdt,@diachi, @email)
go

---------------------------------------------
create proc ThemChiTietXe
@sokhung nvarchar(10),@somay nvarchar(10),@maxe nvarchar(10), @mausac nvarchar(10), @trongluong int,@hopso int, @dungtichbinhxang int, @dungtichxilanh int
AS
	INSERT INTO ChiTietXe(SoKhung,SoMay,MaXe, MauSac, TrongLuong,HopSo, DungTichBinhXang, DungTichXiLanh)
	values (@sokhung, @somay, @maxe, @mausac, @trongluong, @hopso, @dungtichbinhxang, @dungtichxilanh)
go
---------------------------------------------
create proc ThemHangTonKho
@thang int,@nam int, @maxe nvarchar(10), @thoigiantonkho int
AS
	INSERT INTO HangTonKho(Thang, Nam, MaXe, ThoiGianTonKho)
	values (@thang, @nam, @maxe, @thoigiantonkho)
go
---------------------------------------------
create proc ThemHoaDonNhap
@manhap nvarchar(10),@manv nvarchar(10),@mancc nvarchar(10), @tenxe nvarchar(10), @soluong int,@dongia int
AS
	INSERT INTO HoaDonNhap(MaNhap, MaNV, MaNCC, TenXe, SoLuong,DonGia)
	values (@manhap, @manv, @mancc, @tenxe, @soluong, @dongia)
go
---------------------------------------------
Create proc ThemHoaDonXuat
@maxuat nvarchar(10),@manv nvarchar(10),@makh nvarchar(10), @tenxe nvarchar(10), @soluong int,@dongia int
AS
	INSERT INTO HoaDonXuat(MaXuat, MaNV, MaKH, TenXe, SoLuong,DonGia)
	values (@maxuat, @manv, @makh, @tenxe, @soluong, @dongia)
go
---------------------------------------------
Create proc ThemXeTrongCuaHang
@maxe nvarchar(10),@manhap nvarchar(10),@maxuat nvarchar(10), @tenxe nvarchar(10), @dongianhap int,@dongiaxuat int
AS
	INSERT INTO XeTrongCuaHang(MaXe, MaNhap, MaXuat,TenXe, DonGiaNhap, DonGiaXuat)
	values (@maxe, @manhap, @maxuat, @tenxe, @dongianhap, @dongiaxuat)
go
---------------------------------------------
Create proc ThemNhaCungCap
@mancc nvarchar(10),@tenncc nvarchar(30),@sdt nvarchar(11), @diachi nvarchar(50), @email nvarchar(50)
AS
	INSERT INTO NhaCungCap(MaNCC,TenNCC,SDT,DiaChi,Email)
	values (@mancc,@tenncc,@sdt,@diachi,@email)
go
---------------------------------------------
Create proc ThemAccount
@user nvarchar(100),@pass nvarchar(30)
AS
	INSERT INTO Account(UserName, PassWord)
	values (@user, @pass)
go