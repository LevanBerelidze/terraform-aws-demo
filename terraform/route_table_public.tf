resource "aws_route_table" "example_app_public" {
  vpc_id = aws_vpc.example_app.id

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_internet_gateway.example_app.id
  }

  tags = {
    Name = "example_app_public"
  }
}

resource "aws_route_table_association" "example_app_public" {
  subnet_id      = aws_subnet.example_app_public.id
  route_table_id = aws_route_table.example_app_public.id
}
