data "http" "my_ip" {
  url = "https://ident.me"
}

output "my_ip" {
  value = data.http.my_ip.response_body
}

resource "aws_security_group" "example_app" {
  name        = "secg_example_app"
  description = "Allow HTTP/HTTPS"
  vpc_id      = aws_vpc.example_app.id

  ingress {
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    from_port   = 443
    to_port     = 443
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    from_port   = 22
    to_port     = 22
    protocol    = "tcp"
    cidr_blocks = ["${data.http.my_ip.response_body}/32"]
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }

  tags = {
    Name = "example_app"
  }
}
