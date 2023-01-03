resource "aws_subnet" "example_app_public" {
  vpc_id     = aws_vpc.example_app.id
  cidr_block = "10.0.1.0/24"

  tags = {
    Name = "example_app_public"
  }
}

resource "aws_subnet" "example_app_private" {
  vpc_id            = aws_vpc.example_app.id
  cidr_block        = "10.0.2.0/24"
  availability_zone = aws_subnet.example_app_public.availability_zone

  tags = {
    Name = "example_app_private"
  }
}
