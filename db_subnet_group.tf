resource "aws_db_subnet_group" "example_app" {
  name       = "example_app"
  subnet_ids = aws_subnet.example_app_private[*].id


  tags = {
    Name = "example_app"
  }
}
