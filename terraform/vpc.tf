resource "aws_vpc" "example_app" {
  cidr_block = "10.0.0.0/16"

  tags = {
    Name = "example_app"
  }
}
