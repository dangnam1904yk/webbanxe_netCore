USE [webbanxe]
GO
SET IDENTITY_INSERT [dbo].[AdminMenu] ON 
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (1, N'Bảng điều khiển', 0, 0, 1, 0, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (2, N'Thông tin cá nhân', 0, 0, 1, 0, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (3, N'Hướng dẫn sử dụng', 0, 0, 2, 0, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (4, N'Liên lạc', 0, 0, 3, 0, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (5, N'Đăng xuất', 0, 0, 4, 0, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (6, N'Quản lý bài viết', 1, 0, 1, 1, N'components-nav', N'Admin', N'Home', N'Index', N'bi bi-menu-button-wide', N'components-nav')
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (7, N'Cập nhật bài viết', 2, 6, 1, 1, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (8, N'Duyệt và đăng bài viết', 2, 6, 2, 1, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (9, N'Bài viết đã đăng', 2, 6, 3, 1, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (10, N'Quản lý menu', 1, 0, 1, 1, N'forms-nav', N'Admin', N'Home', N'Index', N'bi bi-journal-text', N'forms-nav')
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (11, N'Thêm mới menu', 2, 10, 1, 1, NULL, N'Admin', N'Menu', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (12, N'Chỉnh sửa menu', 2, 10, 2, 1, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (13, N'Quản lý Slide', 1, 0, 1, 1, N'charts-nav', N'Admin', N'Home', N'Index', N'bi bi-bar-chart', N'charts-nav')
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (14, N'Thêm mới Slide', 2, 13, 1, 1, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (15, N'Chỉnh sửa Slide', 2, 13, 2, 1, NULL, N'Admin', N'Home', N'Index', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[AdminMenu] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (1, N'Trang chủ', 1, NULL, NULL, 1, 0, NULL, 1, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (2, N'Về BuyUrBike', 1, NULL, NULL, 1, 0, NULL, 2, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (3, N'Dịch vụ', 1, NULL, NULL, 1, 0, NULL, 3, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (4, N'Chợ xe', 1, NULL, NULL, 1, 0, NULL, 4, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (5, N'Tin tức', 1, NULL, NULL, 1, 0, NULL, 5, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (6, N'Liên hệ', 1, NULL, NULL, 1, 0, NULL, 6, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (7, N'Tư vấn', 1, NULL, NULL, 2, 3, NULL, 1, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (8, N'So sánh xe', 1, NULL, NULL, 2, 3, NULL, 2, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (9, N'Giá linh kiện', 1, NULL, NULL, 2, 3, NULL, 3, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (10, N'Chính sách bảo hành', 1, NULL, NULL, 2, 3, NULL, 4, 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 
GO
INSERT [dbo].[Post] ([PostID], [Title], [Abstract], [Contents], [Images], [Link], [Author], [CreatedDate], [IsActive], [PostOrder], [MenuID], [Category], [Status]) VALUES (1, N'[GIẢI ĐÁP] ĐI XE MÁY ĐIỆN CÓ CẦN MUA BẢO HIỂM KHÔNG? ', N'Như nhiều người đã biết, mua bảo hiểm khi sử dụng xe máy là điều cần thiết và đúng quy định. Tuy nhiên với xe điện, đặc biệt là xe máy điện có cần mua bảo hiểm không? Cùng tìm lời giải đáp ngay trong bài viết dưới đây nhé.', N'1. Xe máy điện có cần bảo hiểm không?
Theo quy định tại Khoản 2, Điều 8 Luật Kinh doanh bảo hiểm, bảo hiểm trách nhiệm dân sự của chủ xe cơ giới là 1 trong số 4 loại bảo hiểm bắt buộc.

Theo quy định tại Khoản 18, Điều 3 Luật Giao thông đường bộ, xe cơ giới gồm xe mô tô hai bánh; xe mô tô ba bánh; xe gắn máy (kể cả xe máy điện). 

Do vậy, chủ xe máy điện phải mua bảo hiểm trách nhiệm dân sự bắt buộc của chủ xe cơ giới (bản cứng hoặc bản điện tử).

Việc mua bảo hiểm cho xe máy điện mang lại nhiều lợi ích như:

Hỗ trợ tài chính cho chủ xe và người bị tai nạn: Giới hạn trách nhiệm bảo hiểm đối với thiệt hại về sức khỏe, tính mạng do xe cơ giới gây ra là 150 triệu đồng/người/vụ tai nạn. Còn đối với tổn thất về tài sản là 50 triệu đồng/vụ tai nạn. 
Bảo đảm an sinh xã hội: Bảo hiểm này được quy định thuộc loại bảo hiểm bắt buộc giúp bảo vệ lợi ích công cộng và an toàn xã hội trong trường hợp không may xảy ra tai nạn giao thông. 
đi xe máy điện có cần bảo hiểm không

Theo quy định, xe máy điện cần mua bảo hiểm trách nhiệm dân sự của xe cơ giới.

2. Chủ xe máy điện không mua bảo hiểm bị phạt bao nhiêu?
Theo Điểm a, Khoản 2 Điều 21 Nghị định 100/2019/NĐ-CP, Khoản 11 Điều 2 Nghị định 123/2021/NĐ-CP, người điều khiển xe máy điện không có hoặc không mang theo bảo hiểm có hiệu lực sẽ bị phạt từ 100.000 đến 200.000 đồng. 

Ngoài ra, theo quy định tại Điểm a Khoản 1 Điều 9 Nghị định 03/2021/NĐ-CP, bảo hiểm xe máy điện có thời hạn tối thiểu 1 năm và tối đa là 3 năm.

3. Mua bảo hiểm cho xe máy điện ở đâu và giá bao nhiêu?
Bạn có thể mua bảo hiểm xe máy điện ở các địa chỉ như:

Tại trụ sở các đơn vị bán bảo hiểm như Bảo hiểm Bảo Việt, Bảo hiểm Quân đội MIC, Tổng công ty bảo hiểm PVI, Bảo hiểm BIC,…
Tại các đại lý phân phối bảo hiểm chính thức, ngân hàng, cây xăng,…
Mua trực tuyến trên website công ty bảo hiểm hoặc ví điện tử, trang thương mại điện tử. 
Mức giá bán bảo hiểm xe máy điện hiện nay là khoảng 55.000 đồng/năm. 

Bài viết trên là thông tin giải đáp cho câu hỏi đi xe máy điện có cần bảo hiểm không. Có thể thấy, mua bảo hiểm chỉ là phương án hạn chế tổn thất khi xảy ra rủi ro. Tuy nhiên bạn cũng cần chấp hành tốt luật lệ giao thông đường bộ và ngay từ ban đầu nên chọn loại xe máy điện chất lượng để đảm bảo an toàn khi điều khiển.', N'/img/blog-1.jpg', N'a', N'Admin', CAST(N'2023-10-20T00:00:00.000' AS DateTime), 1, 1, 5, 1, 1)
GO
INSERT [dbo].[Post] ([PostID], [Title], [Abstract], [Contents], [Images], [Link], [Author], [CreatedDate], [IsActive], [PostOrder], [MenuID], [Category], [Status]) VALUES (2, N'XE MÁY ĐIỆN CÓ PHẢI LẮP GƯƠNG KHÔNG? QUY ĐỊNH THẾ NÀO?', N'Gương chiếu hậu là thiết bị giúp người lái quan sát được phía sau mà không cần quay đầu lại. Nhờ vậy mà việc di chuyển như nhập làn, chuyển làn, vào cua, rẽ trái/phải an toàn hơn. Vậy nếu đi xe máy điện có phải lắp gương không? Tìm hiểu ngay trong bài viết sau đây nhé.', N'1. [Giải đáp] Đi xe máy điện có cần lắp gương không?
Theo Luật giao thông đường bộ Việt Nam, xe máy điện cần lắp gương chiếu hậu khi lưu thông, còn đối với dòng xe điện có tốc độ chạy khoảng 25km/h thì không bắt buộc phải có gương. Cụ thể: 

Theo Điều 53 Luật giao thông đường bộ 2008, có đủ gương chiếu hậu là một trong những điều kiện tham gia giao thông của xe cơ giới. 
Khoản 18 Điều 3 Luật này đã liệt kê các loại xe cơ giới gồm: Xe ô tô; máy kéo; rơ moóc hoặc sơ mi rơ moóc được kéo bởi xe ô tô, máy kéo; xe mô tô hai bánh; xe mô tô ba bánh; xe gắn máy (kể cả xe máy điện) và các loại xe tương tự.
xe máy điện có phải lắp gương không

Theo quy định, sử dụng xe máy điện cần phải lắp gương chiếu hậu.

2. Đi xe máy điện không lắp gương phạt bao nhiêu tiền? 
Theo Điểm a khoản 1 Điều 17 Nghị định số 100/2019/NĐ-CP, xe máy điện không có gương chiếu hậu bên trái hoặc có nhưng không có tác dụng sẽ bị phạt từ 100.000 – 200.000 đồng. Trường hợp không có gương chiếu hậu bên phải thì không bị xử phạt hành chính. 

Người vi phạm có thể nộp phạt trực tiếp, không cần phải đến Kho bạc. Đồng thời người xử phạt không cần lập biên bản nhưng phải xé biên lai đưa cho người vi phạm.

3. Quy định về gương chiếu hậu của xe máy điện 
Không chỉ cần lắp gương vào xe máy điện mà gương chiếu hậu cũng cần đảm bảo chất lượng, lắp đặt đúng cách theo quy chuẩn QCVN 28: 2010/BGTVT về gương chiếu hậu xe mô tô, xe gắn máy. 

Gương phải điều chỉnh được vùng quan sát.
Mép của bề mặt phản xạ gương phải nằm trong vỏ bảo vệ (đế gương) và mép của vỏ bảo vệ phải có bán kính cong “c” có giá trị không nhỏ hơn 2,5 mm tại mọi điểm và theo mọi hướng.
Tất cả các bộ phận của gương phải có bán kính cong “c” không nhỏ hơn 2,5 mm.
Diện tích của bề mặt phản xạ không được nhỏ hơn 69 cm2.
Trong trường hợp gương tròn, đường kính của bề mặt phản xạ không được nhỏ hơn 94 mm và không được lớn hơn 150 mm.
Trong trường hợp gương không tròn kích thước của bề mặt phản xạ phải đủ lớn để chứa được một hình tròn nội tiếp có đường kính 78 mm, nhưng phải nằm được trong một hình chữ nhật có kích thước 120 mm x 200 mm.
Bề mặt phản xạ của gương phải có dạng hình cầu lồi.

Trên đây là những thông tin giải đáp cho thắc mắc xe máy điện có phải lắp gương không. Nhìn chung, bạn nên chọn mua gương xe điện ở những nơi uy tín hoặc sử dụng gương xe chính hãng từ nhà sản xuất. Khi lắp gương, nếu không có nhiều kinh nghiệm thì nên mang ra đại lý hoặc cửa hàng xe để được đội ngũ kỹ thuật hỗ trợ. ', N'/img/blog-2.jpg', N'b', N'Admin', CAST(N'2023-10-21T00:00:00.000' AS DateTime), 1, 1, 5, 1, 1)
GO
INSERT [dbo].[Post] ([PostID], [Title], [Abstract], [Contents], [Images], [Link], [Author], [CreatedDate], [IsActive], [PostOrder], [MenuID], [Category], [Status]) VALUES (3, N'ĐI XE ĐIỆN CÓ CẦN ĐỘI MŨ BẢO HIỂM KHÔNG? QUY ĐỊNH NHƯ THẾ NÀO? ', N'Xe điện là phương tiện được khá nhiều người sử dụng hiện nay. Tuy nhiên đi xe điện có cần đội mũ bảo hiểm không? Quy định cụ thể thế nào? Cùng tìm hiểu chi tiết vấn đề này trong bài viết dưới đây nhé.', N'1. Tìm hiểu về xe điện
Xe điện phổ biến hiện nay có thể kể đến như xe máy điện và xe đạp điện, trong đó: 

Xe máy điện là phương tiện giao thông cơ giới đường bộ có công suất không vượt quá 4000W và vận tốc tối đa dưới 50km/h. Người từ đủ 16 tuổi trở lên có thể sử dụng được xe máy điện.
Xe đạp điện là phương tiện giao thông thô sơ đường bộ, vận tốc tối đa dưới 25km/h, khi tắt máy thì vẫn có thể đạp xe được. Người dưới 16 tuổi có thể sử dụng được xe đạp điện. 
2. Đi xe điện có cần đội mũ bảo hiểm không?
Người điều khiển và người ngồi sau xe máy điện hay xe đạp điện đều cần đội mũ bảo hiểm. Cụ thể: 

Với xe máy điện: Theo Nghị định 100/2019/NĐ-CP, người lái và người ngồi trên xe mô tô, xe gắn máy (bao gồm xe máy điện) bắt buộc phải đội mũ bảo hiểm khi tham gia giao thông.  
Với xe đạp điện: Theo Khoản 2, Điều 31, Luật Giao thông đường bộ năm 2008, người điều khiển, người ngồi trên xe đạp máy phải đội mũ bảo hiểm có cài quai đúng quy cách.
đi xe điện có cần đội mũ bảo hiểm không 1

Người đi xe điện cần đội mũ bảo hiểm và cài quai đúng quy cách khi tham gia giao thông.

3. Lỗi đi xe máy điện không đội mũ bảo hiểm phạt bao nhiêu tiền?
Nếu đi xe máy điện và xe đạp điện không đội mũ bảo hiểm sẽ bị xử phạt hành chính. Căn cứ theo quy định tại Khoản 4, Điều 8, Nghị định 100/2019/NĐ-CP sửa đổi bổ sung bởi Khoản 6 Điều 2 Nghị định 123/2021/NĐ-CP có hiệu lực từ ngày 01/01/2022, phạt tiền từ 400.000 đến 600.000 đồng: 

Người điều khiển xe đạp máy (kể cả xe đạp điện), xe gắn máy (kể cả xe máy điện) không đội “mũ bảo hiểm cho người đi mô tô, xe máy” hoặc đội “mũ bảo hiểm cho người đi mô tô, xe máy” không cài quai đúng quy cách khi tham gia giao thông trên đường bộ.
Chở người ngồi trên xe đạp máy (kể cả xe đạp điện), xe gắn máy (kể cả xe máy điện) không đội “mũ bảo hiểm cho người đi mô tô, xe máy” hoặc đội “mũ bảo hiểm cho người đi mô tô, xe máy” không cài quai đúng quy cách, trừ trường hợp chở người bệnh đi cấp cứu, trẻ em dưới 06 tuổi, áp giải người có hành vi vi phạm pháp luật;
Như vậy, khi đi xe điện, gồm cả xe máy điện và xe đạp điện nếu không đội mũ bảo hiểm, người điều khiển phương tiện có thể bị phạt từ 400.000 đến 600.000 đồng.

Bài viết trên là các thông tin giải đáp cho thắc mắc đi xe điện có cần đội mũ bảo hiểm không. Qua đó, người đi xe điện buộc phải đội mũ bảo hiểm khi tham gia giao thông, nếu không chấp hành có thể bị xử phạt hành chính từ 400.000 – 600.000 đồng. 

Ngoài tuân thủ quy định khi tham gia giao thông, bạn cũng cần lưu ý lựa chọn loại xe điện chất lượng để đảm bảo an toàn khi di chuyển cũng như có trải nghiệm lái tốt hơn. ', N'/img/blog-3.jpg', N'c', N'Admin', CAST(N'2023-10-19T00:00:00.000' AS DateTime), 1, 1, 3, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
