resource "aws_subnet" "example_app_public" {
  vpc_id     = aws_vpc.example_app.id
  cidr_block = "10.0.1.0/24"

  tags = {
    Name = "example_app_public"
  }
}

data "aws_availability_zones" "available" {}

resource "aws_subnet" "example_app_private" {
  count             = 2
  vpc_id            = aws_vpc.example_app.id
  cidr_block        = "10.0.${2 + count.index}.0/24"
  availability_zone = data.aws_availability_zones.available.names[count.index]

  tags = {
    Name = "example_app_private_${count.index + 1}"
  }
}
