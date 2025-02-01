resource "aws_security_group" "example_app_db" {
  name        = "secg_example_app_db"
  description = "Allow MySQL from EC2 subnet"
  vpc_id      = aws_vpc.example_app.id

  ingress {
    from_port   = 3306
    to_port     = 3306
    protocol    = "tcp"
    cidr_blocks = [aws_subnet.example_app_public.cidr_block]
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }

  tags = {
    Name = "example_app_db"
  }
}
