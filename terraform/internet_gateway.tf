resource "aws_internet_gateway" "example_app" {
  vpc_id = aws_vpc.example_app.id

  tags = {
    Name = "example_app"
  }
}
